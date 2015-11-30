using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Web.Models;
using Microsoft.Data.Entity;
using Web.Models.Repositories;
using Web.Classes;
using Newtonsoft.Json.Serialization;

namespace Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().
                AddJsonOptions(option =>
                {
                    option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<UtilitiesContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddScoped<IBillTypeRepository, BillTypeRepository>();
            services.AddScoped<IBillProviderRepository, BillProviderRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            SampleData.Initialize(app.ApplicationServices);
            Mapping.Initialize();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
