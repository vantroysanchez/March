using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public int SaveChanges()
        {
            return _repository.CommitChanges();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
