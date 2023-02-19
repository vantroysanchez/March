using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDetailService
    {
        IEnumerable<Detail> GetAll();
    }
}