using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Mappings
{
    public class AgendaMap : Profile
    {
        public AgendaMap()
        {
            CreateMap<Agenda, AgendaDto>().ReverseMap();
        }
    }
}
