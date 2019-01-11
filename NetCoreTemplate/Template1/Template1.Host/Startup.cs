using BMW.Omc.ConfigService.Client.Instrument.Wrappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template1.Host.Attributes;
using Template1.Host.Extensions;
using Template1.Host.Infrastructure;

namespace Template1.Host
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// IConfiguration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddApplicationInsightsTelemetry("4d289461-17c9-475c-83dc-a3249d929aba");
            services.AddRegisters();
            services.AddDbContext();
            services.AddSwaggerService();

            services.AddMvc(
                options =>
                {
                    options.Filters.Add<AiHandleExceptionAttribute>();
                });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IHostingEnvironment</param>
        /// <param name="aft">IApplicationLifetime</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime aft)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.AddSwaggerConfig();

            aft.ApplicationStopping.Register(() =>
            {
                Bootstrap.AppInsightsTelemetryClient.TrackEvent("application are stopping");
            });

            app.UseMvc();
        }
    }
}
