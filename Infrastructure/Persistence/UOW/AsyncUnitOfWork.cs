using Application.Common.Interfaces;
using Domain.Common;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.UOW
{
    public class AsyncUnitOfWork : IAsyncUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Hashtable _repositories;

        public AsyncUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositories ??= new Hashtable();
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
            => await _context.DisposeAsync();

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : Audit
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(AsyncRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return _repositories[type] as IAsyncRepository<TEntity>;
        }
    }
}
