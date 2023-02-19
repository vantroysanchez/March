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
    class HeaderRepository: BaseRepository<Header>, IHeaderRepository
    {
        public HeaderRepository(ApplicationDbContext context): base(context) { }
    }
}
