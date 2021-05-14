using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestTaskProm.DAL;
using TestTaskProm.DAL.Identity;
using TestTaskProm.DAL.Identity.Models;
using TestTaskProm.Common;
using TestTaskProm.Web.Services;
using TestTaskProm.DAL.Interfaces;
using TestTaskProm.Web.Infrastructure;
using Serilog;

namespace TestTaskProm
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureSql(services);

            this.ConfigureIdentity(services);
            this.ConfigureAutomapper(services);
            services.AddControllersWithViews();

            this.ConfigureDependency(services);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddMemoryCache();
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            });
        }

        private void ConfigureDependency(IServiceCollection services)
        {
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAddressRepository, AddressRepository>();
        }

        private void ConfigureSql(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TestTaskPromContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }

        private void ConfigureAutomapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
    }
}
