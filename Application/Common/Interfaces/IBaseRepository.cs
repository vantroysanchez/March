using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace Application.Common.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        int CommitChanges();
        T GetById(object id);
        IQueryable<T> Get(Expression<Func<T, bool>> where, string includeProperties = "");
        IQueryable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        IQueryable<T> Get(params Expression<Func<T, object>>[] include);
        IQueryable<T> GetAll();
        int Count();
        T Insert(T entity);
        T Update(T entity);
        T Update(T entity, object id);
        void UpdateProperty<Type>(Expression<Func<T, Type>> property, T entity);
        void Delete(T Entity);
        void Delete(object id);
        void Delete(Expression<Func<T, bool>> primaryKeys);
        SqlDataReader Run(string query);
        void DeleteRange(IEnumerable<T> entity);
        IEnumerable<T> InsertRange(IEnumerable<T> entity);
        void DetacheEntity(T entity);
    }
}
