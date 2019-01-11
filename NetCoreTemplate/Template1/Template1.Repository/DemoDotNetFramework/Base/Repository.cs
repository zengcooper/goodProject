using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template1.Common.Configuration;
using Template1.Entity;
using Template1.EntityFrameworkCore;

namespace Template1.Repository.DemoDotNetFramework.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbSet<T> DbSet { get; private set; }
        protected DemoDotNetFrameworkDbContext dataContext;
        protected IDemoConfiguration _demoConfiguration;

        public Repository(IDemoDotNetFrameworkDatabaseFactory databaseFactory,
            IDemoConfiguration demoConfiguration)
        {
            _demoConfiguration = demoConfiguration;
            DatabaseFactory = databaseFactory;
            DbSet = DataContext.Set<T>();
            dataContext.Database.SetCommandTimeout(_demoConfiguration.DemoDotNetCoreDbCommandTimeout);
        }

        protected IDemoDotNetFrameworkDatabaseFactory DatabaseFactory { get; }

        protected virtual DemoDotNetFrameworkDbContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get(_demoConfiguration.DemoDotNetFrameworkDbConnectionString)); }
        }

        public virtual int Add(T entity)
        {
            DbSet.Add(entity);
            return DataContext.SaveChanges();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            DbSet.Add(entity);
            return await DataContext.SaveChangesAsync();
        }

        public virtual void BulkAddWithCommit(IEnumerable<T> entities)
        {

            int i = 0;

            foreach (T entity in entities)
            {
                DbSet.Add(entity);
                // save every 100 items
                if ((++i) % 100 == 0)
                {
                    DataContext.SaveChanges();
                }
            }
            // save rest items
            DataContext.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            DbSet.Update(entity);
            return DataContext.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            return await DataContext.SaveChangesAsync();
        }

        public virtual int Delete(T entity)
        {
            DbSet.Remove(entity);
            return DataContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            return await DataContext.SaveChangesAsync();
        }

        public virtual int Delete(Expression<Func<T, bool>> where)
        {
            var objects = DbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return DataContext.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return DbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return DbSet.FirstOrDefault(where);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.AsNoTracking().Where(where).SingleOrDefaultAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return DbSet.Where(where).ToList();
        }

        public async Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.Where(where).ToListAsync();
        }

        public Tuple<int, IList<T>> GetListByPage<TKey>(Expression<Func<T, bool>> where, Func<T, TKey> keySelector, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 10 : pageSize;
            var skip = (pageIndex - 1) * pageSize;
            var query = DbSet.Where(where).OrderByDescending(keySelector);
            var count = query.Count();
            var list = query.Skip(skip).Take(pageSize);
            return new Tuple<int, IList<T>>(count, list == null ? new List<T>() : list.ToList());
        }
    }
}
