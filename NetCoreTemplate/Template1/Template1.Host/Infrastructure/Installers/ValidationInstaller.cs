using Microsoft.Extensions.DependencyInjection;
using Template1.Services.Microservice.Validation;

namespace Template1.Host.Infrastructure.Installers
{
    /// <summary>
    /// Validation Installer
    /// </summary>
    public static class ValidationInstaller
    {
        /// <summary>
        /// Add Validations Register
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddValidationsRegister(this IServiceCollection services)
        {
            services.AddSingleton<IMicroserviceValidation, MicroserviceValidation>();
        }
    }
}
