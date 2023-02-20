using Application.Common.Interfaces;
using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDetailService
    {
        IQueryable<Detail> GetAll();
        Detail GetById(int id);
        void Insert(DetailDto entity);
    }
}