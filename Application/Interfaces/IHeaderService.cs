using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IHeaderService
    {
        void Delete(int id);
        IQueryable<Header> GetAll();
        Header GetById(int id);
        void Insert(HeaderDto entity);
        void Update(int id, HeaderDto entity);
    }
}