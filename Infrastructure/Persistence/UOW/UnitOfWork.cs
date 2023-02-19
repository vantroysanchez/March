using Application.Common.Interfaces;
using Application.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Header = new HeaderRepository(_context);
            Detail = new DetailRepository(_context);
            
        }
        public IHeaderRepository Header
        {
            get;
            private set;
        }
        public IDetailRepository Detail
        {
            get;
            private set;
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
