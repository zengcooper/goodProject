using BMW.Omc.ConfigService.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using Template1.EntityFrameworkCore;
using Template1.Host.Infrastructure;

namespace Template1.Host.Extensions
{
    /// <summary>
    /// Startup Extensions
    /// </summary>
    public static class StartupExtensions
    {
        /// <summary>
        /// Add Registers
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddRegisters(this IServiceCollection services)
        {
            //register ApplicationInsights,OmcRunner
            services.AddOmcClient();
            //register application objects
            Bootstrap.Initialize(services);
        }

        /// <summary>
        /// Add DbContext
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddDbContext(this IServiceCollection services)
        {
            var builderDb = new DbContextOptionsBuilder<DemoDotNetCoreDbContext>();
            builderDb.UseSqlServer(Bootstrap.DemoConfiguration.DemoDotNetCoreDbConnectionString);
            using (var context = new DemoDotNetCoreDbContext(builderDb.Options))
            {
                context.Database.Migrate();
            }

            services.AddDbContext<DemoDotNetCoreDbContext>(
                options => options.UseSqlServer(Bootstrap.DemoConfiguration.DemoDotNetCoreDbConnectionString));
        }

        /// <summary>
        /// Add SwaggerService
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddSwaggerService(this IServiceCollection services)
        {
            try
            {
                // swagger is show or not depend on setting["EnableSwaggerDocument"]
                if (Bootstrap.DemoConfiguration.EnableSwaggerDocument)
                {
                    services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new Info
                        {
                            Version = "v1",
                            Title = "Template1",
                            Description = "Provide and support by Wheel",
                            // Service owner ifno
                            Contact = new Contact
                            {
                                Name = "Wheel",
                                Email = "Wheel@bmw.com"
                            }
                        });
                        // If need add header parameter,such as token, 
                        // remonve comment and edit AuthTokenHeaderParameter is for add head parameters
                        //// Add AuthTokenParameter
                        //options.OperationFilter<AuthTokenParameter>();

                        // Set the comments path for the Swagger JSON and UI. 
                        var AssemblyName = "Template1";
                        var controllerXmlFile = Path.Combine(AppContext.BaseDirectory, $"{AssemblyName}.Host.xml");
                        var contractsXmlPath = Path.Combine(AppContext.BaseDirectory, $"{AssemblyName}.Contract.xml");
                        options.IncludeXmlComments(controllerXmlFile, true);
                        options.IncludeXmlComments(contractsXmlPath, true);
                    });
                    services.ConfigureSwaggerGen();
                }
            }
            catch (Exception ex)
            {
                Bootstrap.AppInsightsTelemetryClient.TrackException(ex);
            }
        }

        /// <summary>
        /// Add SwaggerConfig
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void AddSwaggerConfig(this IApplicationBuilder app)
        {
            try
            {
                // swagger is show or not depend on setting["EnableSwaggerDocument"]
                if (Bootstrap.DemoConfiguration.EnableSwaggerDocument)
                {
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template1 API V1");
                    });
                }
            }
            catch (Exception ex)
            {
                Bootstrap.AppInsightsTelemetryClient.TrackException(ex);
            }
        }
    }
}