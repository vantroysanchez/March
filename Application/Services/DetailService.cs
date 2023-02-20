using Application.Common.Interfaces;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class DetailService : IDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DetailService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _uow.Detail.Delete(id);
            _uow.SaveChanges();
        }

        public IQueryable<Detail> GetAll()
        {
            var detail = _uow.Detail.GetAll();

            return detail;
        }

        public Detail GetById(int id)
        {
            var detail = _uow.Detail.GetById(id);

            return detail;
        }

        public void Insert(DetailDto entity)
        {            
            _uow.Detail.Insert(_mapper.Map<Detail>(entity));
            _uow.SaveChanges();
        }        

        public void Update(int id, DetailDto entity)
        {
            var detail = _uow.Detail.GetById(id);

            detail.Description = entity.Description;
            detail.Quantity = entity.Quantity;
            detail.Amount = entity.Amount;
            detail.HeaderId = entity.HeaderId;

            _uow.Detail.Update(detail);
            _uow.SaveChanges();
        }
        
    }
}
