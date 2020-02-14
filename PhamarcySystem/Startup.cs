using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhamarcySystem.Data;
using PhamarcySystem.Models;

namespace PhamarcySystem
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
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(
                 options =>
                 {
                     // Password settings
                     options.Password.RequireDigit = true;
                     options.Password.RequiredLength = 6;
                     options.Password.RequireNonAlphanumeric = true;
                     options.Password.RequireUppercase = false;
                     options.Password.RequireLowercase = true;
                     options.Password.RequireNonAlphanumeric = true;
                     options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/";
                     // Lockout settings
                     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(9);
                     options.Lockout.MaxFailedAccessAttempts = 2;
                     options.Lockout.AllowedForNewUsers = true;

                     // User settings
                     options.User.RequireUniqueEmail = true;



                 });
            services.AddMvc();
            services.AddTransient<Func<ehealthContext>>(cont => () => cont.GetService<ehealthContext>());
            services.AddMvc().AddControllersAsServices();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddAuthentication();

            // services.AddTransient<IEmailSender>();
            services.AddAntiforgery();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                //options.Cookie.HttpOnly = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseIdentity();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
name: "default_route",
template: "{controller}/{action}/{id?}",
defaults: new { controller = "Account", action = "Login" });
            });
        }
    }
}