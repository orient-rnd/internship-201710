using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Interns2.Infrastructure.MongoDb;
using Interns2.AppServices.FlashCard.Services;
using Microsoft.AspNetCore.Identity;
using Interns2.Domain.Domains;

namespace Interns2.AppServices.FlashCard
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
            services.AddMvc();

            services.AddSingleton<IMongoDbWriteRepository>(sp =>
            {
                return new MongoDbWriteRepository("mongodb://interns2:interns2@ds117485.mlab.com:17485/interns2");
            });

            services.AddTransient<IUserService, UserService>();

            //services.AddIdentity<User, IdentityRole>()
            //.AddEntityFrameworkStores

            //IMongoDbWriteRepository

            services.AddIdentity<User, IdentityRole>(
            identityOptions =>
            {
                // Email settings
                identityOptions.User.RequireUniqueEmail = true;

                // Password settings
                identityOptions.Password.RequiredLength = 8;
                identityOptions.Password.RequireDigit = false;
                identityOptions.Password.RequireNonAlphanumeric = false;
                identityOptions.Password.RequireUppercase = false;
                identityOptions.Password.RequireLowercase = false;

                // Lockout settings
                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                identityOptions.Lockout.MaxFailedAccessAttempts = 10;
            })
            .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
