using Domain.Common;
using System.Linq.Expressions;

namespace Application.Common.Interfaces
{
    public interface IAsyncRepository<T> where T : Audit
    {
        Task<T> AddAsync(T entity);
        void AddEntity(T entity);
        Task DeleteAsync(T entity);
        void DeleteEntity(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTrancking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeString = null, bool disableTrancking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
        void UpdateEntity(T entity);
    }
}