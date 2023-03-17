using Application.Common.Interfaces;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class DetailService : IDetailService
    {
        private readonly IAsyncUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DetailService(IAsyncUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var entity = await _uow.Repository<Detail>().GetByIdAsync(id);

            await _uow.Repository<Detail>().DeleteAsync(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Detail>> GetAllAsync()
        {
            return await _uow.Repository<Detail>().GetAllAsync();            
        }

        public async Task<Detail> GetById(int id)
        {
            var detail = await _uow.Repository<Detail>().GetByIdAsync(id);

            return detail;
        }

        public async Task Insert(DetailDto entity)
        {            
            await _uow.Repository<Detail>().AddAsync(_mapper.Map<Detail>(entity));
            await _uow.SaveChangesAsync();
        }        

        public async Task Update(int id, DetailDto entity)
        {
            var detail = await _uow.Repository<Detail>().GetByIdAsync(id);

            detail.Description = entity.Description;
            detail.Quantity = entity.Quantity;
            detail.Amount = entity.Amount;
            detail.HeaderId = entity.HeaderId;

            await _uow.Repository<Detail>().UpdateAsync(detail);
            await _uow.SaveChangesAsync();
        }
        
    }
}
