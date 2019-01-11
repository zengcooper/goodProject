using Microsoft.EntityFrameworkCore;
using Template1.Entity.DemoDotNetCore;

namespace Template1.EntityFrameworkCore
{
    public class DemoDotNetCoreDbContext : DbContext
    {
        public DemoDotNetCoreDbContext(DbContextOptions<DemoDotNetCoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<MicroserviceEntity> Microservices { get; set; }
        public DbSet<ServiceDefinitionEntity> ServiceDefinitions { get; set; }

    }
}
