using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template1.Entity;

namespace Template1.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        //bool RefreshEntityInContext(T entity);

        int Add(T entity);
        Task<int> AddAsync(T entity);
        void BulkAddWithCommit(IEnumerable<T> entities);

        int Update(T entity);
        Task<int> UpdateAsync(T entity);

        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        int Delete(Expression<Func<T, bool>> where);

        T GetById(int id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> where);

        Tuple<int, IList<T>> GetListByPage<TKey>(Expression<Func<T, bool>> where, Func<T, TKey> keySelector, int pageIndex, int pageSize);
    }
}
