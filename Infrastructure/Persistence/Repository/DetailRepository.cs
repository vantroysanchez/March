using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    class DetailRepository: BaseRepository<Detail>, IDetailRepository
    {
        public DetailRepository(ApplicationDbContext context) : base(context) { }
    }
}
