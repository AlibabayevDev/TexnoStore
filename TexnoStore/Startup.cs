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
using TexnoStoreWebCore.Services.Implementations;
using TexnoStoreWebCore.Services.Abstract;
using EmailService.Services.Abstract;
using EmailService.Services.Implementations;
using EmailService.Factory;

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
            services.AddSingleton((t) =>
            {
                return EmailFactory.Create();
            });
            services.AddIdentity<User, Role>(opts => {
                opts.Password.RequiredLength = 5;   // ??????????? ?????
                opts.Password.RequireNonAlphanumeric = false;   // ????????? ?? ?? ?????????-???????? ???????
                opts.Password.RequireLowercase = false; // ????????? ?? ??????? ? ?????? ????????
                opts.Password.RequireUppercase = false; // ????????? ?? ??????? ? ??????? ????????
                opts.Password.RequireDigit = false; // ????????? ?? ?????
            }).AddDefaultTokenProviders(); ;

            services.AddSingleton<IPasswordHasher<User>, CustomPasswordHasher>();
            services.AddSingleton<IUserStore<User>, UserStore>();
            services.AddSingleton<IRoleStore<Role>, RoleStore>();
            services.AddSingleton<IUnitOfWorkService, UnitOfWorkService>();
            //services.AddSingleton<IEmailService, EmailServiceSender>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true; // asking client for cookies accept
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            //.AddGoogle(options =>
            //{
            //    options.ClientId = Configuration["Authentication:Google:ClientId"];
            //    options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //    options.SignInScheme = IdentityConstants.ExternalScheme;
            //});


           //.AddFacebook(facebookOptions =>
           //{
           //    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
           //    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"]; 
           //});
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
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
