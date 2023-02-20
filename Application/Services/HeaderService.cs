using Application.Common.Interfaces;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HeaderService : IHeaderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public HeaderService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _uow.Header.Delete(id);
            _uow.SaveChanges();
        }

        public IQueryable<Header> GetAll()
        {
            var header = _uow.Header.GetAll().Include(x => x.Details);

            return header;
        }

        public Header GetById(int id)
        {
            var header = _uow.Header.GetById(id);

            return header;
        }

        public void Insert(HeaderDto entity)
        {
            _uow.Header.Insert(_mapper.Map<Header>(entity));
            _uow.SaveChanges();
        }

        public void Update(int id, HeaderDto entity)
        {
            var header = _uow.Header.GetById(id);

            header.Description = entity.Description;
            header.TotalAmount = entity.TotalAmount;
            header.Code = entity.Code;

            _uow.Header.Update(header);
            _uow.SaveChanges();
        }
    }
}
