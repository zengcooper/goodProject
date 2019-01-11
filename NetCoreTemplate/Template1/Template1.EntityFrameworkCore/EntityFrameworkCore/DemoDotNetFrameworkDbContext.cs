using Microsoft.EntityFrameworkCore;

namespace Template1.EntityFrameworkCore
{
    public class DemoDotNetFrameworkDbContext : DbContext
    {
        public const string SchemaName = "dbo";

        public DemoDotNetFrameworkDbContext(DbContextOptions<DemoDotNetFrameworkDbContext> options)
            : base(options)
        {
        }

    }
}
