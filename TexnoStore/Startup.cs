using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TexnoStore.Core.Factory;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.IdentityServer;
using TexnoStore.Core.DataAccess.Implementation.SQL;
using TexnoStore.Core.IdentityServer;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TexnoStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddSingleton((t) =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");

                return DbFactory.Create(connectionString);
            });
            services.AddIdentity<User, Role>(opts => {
                opts.Password.RequiredLength = 5;   // ??????????? ?????
                opts.Password.RequireNonAlphanumeric = false;   // ????????? ?? ?? ?????????-???????? ???????
                opts.Password.RequireLowercase = false; // ????????? ?? ??????? ? ?????? ????????
                opts.Password.RequireUppercase = false; // ????????? ?? ??????? ? ??????? ????????
                opts.Password.RequireDigit = false; // ????????? ?? ?????
            });
            services.AddSingleton<IPasswordHasher<User>, CustomPasswordHasher>();
            services.AddSingleton<IUserStore<User>, UserStore>();
            services.AddSingleton<IRoleStore<Role>, RoleStore>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/account/google-login"; // Must be lowercase
            })
           .AddGoogle(options =>
            {
                options.ClientId = "54033117845-k26estikeml9j6h0r2uh27n90opvsrg4.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
