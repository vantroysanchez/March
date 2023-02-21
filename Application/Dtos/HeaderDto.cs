using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos
{
    public class HeaderDto: IMapFrom<Header>
    {
        public HeaderDto()
        {
            Details = new List<DetailDto>();
        }

        public int Code { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Status { get; set; }

        public List<DetailDto> Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Header, HeaderDto>().ReverseMap();
        }

    }
}
