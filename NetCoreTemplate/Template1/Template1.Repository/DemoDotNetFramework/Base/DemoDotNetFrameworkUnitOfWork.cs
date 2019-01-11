using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Template1.Common.Configuration;
using Template1.EntityFrameworkCore;

namespace Template1.Repository.DemoDotNetFramework.Base
{
    public class DemoDotNetFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly IDemoDotNetFrameworkDatabaseFactory _databaseFactory;
        private DemoDotNetFrameworkDbContext dataContext;
        private IDemoConfiguration _demoConfiguration;

        public DemoDotNetFrameworkUnitOfWork(IDemoDotNetFrameworkDatabaseFactory databaseFactory,
            IDemoConfiguration demoConfiguration)
        {
            _databaseFactory = databaseFactory;
            _demoConfiguration = demoConfiguration;
        }

        protected DemoDotNetFrameworkDbContext DataContext
        {
            get { return dataContext ?? (dataContext = _databaseFactory.Get(_demoConfiguration.DemoDotNetFrameworkDbConnectionString)); }
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
