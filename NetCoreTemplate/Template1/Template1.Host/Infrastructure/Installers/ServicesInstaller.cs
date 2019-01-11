using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Template1.Services.Microservice;

namespace Template1.Host.Infrastructure.Installers
{
    /// <summary>
    /// ServicesInstaller
    /// </summary>
    public static class ServicesInstaller
    {
        /// <summary>
        /// AddServicesRegister
        /// </summary>
        /// <param name="services"></param>
        public static void AddServicesRegister(this IServiceCollection services)
        {
            services.AddSingleton<IMicroserviceService, MicroserviceService>();
        }
    }
}
