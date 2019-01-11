using Microsoft.Extensions.DependencyInjection;
using Template1.EntityFrameworkCore;
using Template1.Repository;
using Template1.Repository.DemoDotNetCore;
using Template1.Repository.DemoDotNetCore.Base;
using Template1.Repository.DemoDotNetFramework.Base;

namespace Template1.Host.Infrastructure.Installers
{
    /// <summary>
    /// Repositories Installer
    /// </summary>
    public static class RepositoriesInstaller
    {
        /// <summary>
        /// Add Repository Register
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddRepositoryRegister(this IServiceCollection services)
        {
            //registe dbcontext
            services.AddTransient<DemoDotNetCoreDbContext>();

            //registe database
            services.AddTransient<IDemoDotNetCoreDatabaseFactory, DemoDotNetCoreDatabaseFactory>();
            services.AddTransient<IUnitOfWork, DemoDotNetCoreUnitOfWork>();

            //registe repository
            services.AddTransient<IMicroserviceRepository, MicroserviceRepository>();
            services.AddTransient<IServiceDefinitionRepository, ServiceDefinitionRepository>();

        }
    }
}
