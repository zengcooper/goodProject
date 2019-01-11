using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Template1.EntityFrameworkCore
{
    public class DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DemoDotNetCoreDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DemoDotNetCoreDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }


        public static void Configure(DbContextOptionsBuilder<DemoDotNetFrameworkDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DemoDotNetFrameworkDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
