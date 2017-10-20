using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Interns2.Infrastructure.MongoDb;
using Microsoft.AspNetCore.Identity;
using Interns2.Domain.Domains;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Core;
using Intern2.Infrastructure.Identity.MongoDb;
using Interns2.Domain.Users.Models;

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
            services.AddIdentity<User, Role>(
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

                    // Cookie settings
                    //identityOptions.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(365);
                    //identityOptions.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                    //identityOptions.Cookies.ApplicationCookie.LogoutPath = "/Account/Logout";
                })
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddSingleton<IMongoDbWriteRepository>(sp =>
            {
                return new MongoDbWriteRepository("mongodb://interns2:interns2@ds117485.mlab.com:17485/interns2");
            });            

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterType<UserStore<User, Role>>()
                .WithParameters(new[]
                {
                    new ResolvedParameter(
                        (p, c) => p.Name == "users",
                        (p, c) => c.Resolve<IMongoDbWriteRepository>().GetCollection<User>()),
                    new ResolvedParameter(
                        (p, c) => p.Name == "roles",
                        (p, c) => c.Resolve<IMongoDbWriteRepository>().GetCollection<Role>())
                })
                .As<IUserStore<User>>();

            containerBuilder.RegisterType<RoleStore<Role>>()
                .WithParameters(new[]
                {
                    new ResolvedParameter(
                        (p, c) => p.Name == "roles",
                        (p, c) => c.Resolve<IMongoDbWriteRepository>().GetCollection<Role>())
                })
                .As<IRoleStore<Role>>();
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
