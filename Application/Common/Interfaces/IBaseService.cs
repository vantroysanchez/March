using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        int SaveChanges();
        void Update(T entity);
        void Delete(int id);
    }
}
