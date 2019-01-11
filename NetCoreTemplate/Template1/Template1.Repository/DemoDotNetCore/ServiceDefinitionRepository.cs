using Template1.Common.Configuration;
using Template1.Entity.DemoDotNetCore;
using Template1.Repository.DemoDotNetCore.Base;

namespace Template1.Repository.DemoDotNetCore
{
    public interface IServiceDefinitionRepository : IRepository<ServiceDefinitionEntity>
    {

    }

    public class ServiceDefinitionRepository : Repository<ServiceDefinitionEntity>, IServiceDefinitionRepository
    {
        public ServiceDefinitionRepository(IDemoDotNetCoreDatabaseFactory databaseFactory,
            IDemoConfiguration demoConfiguration)
            : base(databaseFactory, demoConfiguration)
        {

        }

    }
}
