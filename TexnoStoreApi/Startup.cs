using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Factory;
using TexnoStore.Core.IdentityServer;
using TexnoStore.IdentityServer;

namespace TexnoStoreApi
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
            }).AddDefaultTokenProviders(); ;

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
               options.ClientId = Configuration["Authentication:Google:ClientId"];
               options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
               options.SignInScheme = IdentityConstants.ExternalScheme;
           });
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
