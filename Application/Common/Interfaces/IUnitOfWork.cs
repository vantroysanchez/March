using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IHeaderRepository Header
        {
            get;
        }
        IDetailRepository Detail
        {
            get;
        }
        
        int SaveChanges();
    }
}
