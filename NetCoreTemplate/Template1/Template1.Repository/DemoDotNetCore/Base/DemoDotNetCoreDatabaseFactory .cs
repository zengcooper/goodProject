using Microsoft.EntityFrameworkCore;
using Template1.EntityFrameworkCore;

namespace Template1.Repository.DemoDotNetCore.Base
{
    public class DemoDotNetCoreDatabaseFactory : IDemoDotNetCoreDatabaseFactory
    {
        public DemoDotNetCoreDbContext Get(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<DemoDotNetCoreDbContext>();
            builder.UseSqlServer(connectionString);
            return new DemoDotNetCoreDbContext(builder.Options);
        }
    }

    public interface IDemoDotNetCoreDatabaseFactory
    {
        DemoDotNetCoreDbContext Get(string connectionString);
    }
}
