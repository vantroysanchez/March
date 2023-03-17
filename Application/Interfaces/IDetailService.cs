using Application.Common.Interfaces;
using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDetailService
    {
        Task<IReadOnlyList<Detail>> GetAllAsync();        
        Task<Detail> GetById(int id);
        Task Insert(DetailDto entity);
        Task Update(int id, DetailDto entity);
        Task Delete(int id);
    }
}