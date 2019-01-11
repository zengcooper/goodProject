using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Template1.Host.Controllers;

namespace Template1.Host.Infrastructure.Installers
{
    /// <summary>
    /// ControllerInstaller
    /// </summary>
    public static class ControllerInstaller
    {
        /// <summary>
        /// AddServicesRegister
        /// </summary>
        /// <param name="services"></param>
        public static void AddControllersRegister(this IServiceCollection services)
        {
            //services.AddSingleton(Classes.FromAssemblyInThisApplication(typeof(Controller).Assembly)
            //                    .BasedOn<BaseController>().LifestyleTransient());

            var controllers = typeof(BaseController).Assembly.ExportedTypes.Where(k =>
                k.FullName.EndsWith("Controller", StringComparison.InvariantCultureIgnoreCase)
                && !k.FullName.EndsWith("BaseController"));
            foreach (var item in controllers)
            {
                services.AddSingleton(item);
            }
        }
    }
}
