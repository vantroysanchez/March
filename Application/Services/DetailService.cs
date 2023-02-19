using Application.Common.Interfaces;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DetailService : IDetailService
    {
        private readonly IUnitOfWork _uow;

        public DetailService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Detail> GetAll()
        {
            var detail = _uow.Detail.GetAll();

            return detail;
        }
    }
}
