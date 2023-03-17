using Application.Common.Interfaces;
using Domain.Common;

namespace Application.Common.Interfaces
{
    public interface IAsyncUnitOfWork
    {
        ValueTask DisposeAsync();
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : Audit;
        Task<int> SaveChangesAsync();
    }
}