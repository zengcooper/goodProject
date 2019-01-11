using BMW.Omc.ConfigService.Client.Instrument.Wrappers;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Template1.Common.Configuration;
using Template1.Host.Infrastructure.Installers;

namespace Template1.Host.Infrastructure
{
    /// <summary>
    /// Bootstrap
    /// </summary>
    public class Bootstrap
    {
        private static IServiceCollection _services;

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void Initialize(IServiceCollection services)
        {
            _services = services;
            services.AddSingleton<IDemoConfiguration, DemoConfiguration>();

            //first register repository
            services.AddRepositoryRegister();
            //second register Validation
            services.AddValidationsRegister();
            //third register service
            services.AddServicesRegister();
            services.AddControllersRegister();

            DemoConfiguration = services.BuildServiceProvider().GetService<IDemoConfiguration>();
            AppInsightsTelemetryClient = services.BuildServiceProvider().GetService<IAppInsightsTelemetryClient>();
            AppInsightsTelemetryClient = AppInsightsTelemetryClient ?? new AITelemetryClientWrapper();
        }

        /// <summary>
        /// DemoConfiguration
        /// </summary>
        public static IDemoConfiguration DemoConfiguration { get; private set; }

        /// <summary>
        /// AppInsightsTelemetry Client
        /// </summary>
        public static IAppInsightsTelemetryClient AppInsightsTelemetryClient { get; private set; }

        /// <summary>
        /// GetService
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static object GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;

            var service = _services.BuildServiceProvider().GetService(serviceType);
            if (service == null)
            {
                AppInsightsTelemetryClient.TrackTrace(serviceType.Name, SeverityLevel.Warning);
            }

            return service;
        }

        /// <summary>
        /// GetServices
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                return null;
            return _services.BuildServiceProvider().GetServices(serviceType);
        }

    }
}
