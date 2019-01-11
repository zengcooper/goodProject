using Microsoft.EntityFrameworkCore;
using Template1.Common;
using Template1.EntityFrameworkCore;

namespace Template1.Repository.DemoDotNetFramework.Base
{
    public class DemoDotNetFrameworkDatabaseFactory : IDemoDotNetFrameworkDatabaseFactory
    {
        public DemoDotNetFrameworkDbContext Get(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<DemoDotNetFrameworkDbContext>();
            builder.UseSqlServer(connectionString);
            return new DemoDotNetFrameworkDbContext(builder.Options);
        }

    }

    public interface IDemoDotNetFrameworkDatabaseFactory
    {
        DemoDotNetFrameworkDbContext Get(string connectionString);
    }
}
