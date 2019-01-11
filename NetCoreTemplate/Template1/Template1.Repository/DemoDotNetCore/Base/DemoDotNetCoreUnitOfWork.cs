using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Template1.Common.Configuration;
using Template1.EntityFrameworkCore;

namespace Template1.Repository.DemoDotNetCore.Base
{
    public class DemoDotNetCoreUnitOfWork : IUnitOfWork
    {
        private readonly IDemoDotNetCoreDatabaseFactory databaseFactory;
        private DemoDotNetCoreDbContext dataContext;
        private IDemoConfiguration _demoConfiguration;

        public DemoDotNetCoreUnitOfWork(IDemoDotNetCoreDatabaseFactory databaseFactory,
            IDemoConfiguration demoConfiguration)
        {
            this.databaseFactory = databaseFactory;
            _demoConfiguration = demoConfiguration;
        }

        protected DemoDotNetCoreDbContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get(_demoConfiguration.DemoDotNetCoreDbConnectionString)); }
        }

        public int Commit()
        {
            return DataContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await DataContext.SaveChangesAsync();
        }
    }

}
