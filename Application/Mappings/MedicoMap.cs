using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Mappings
{
    public class MedicoMap : Profile
    {
        public MedicoMap()
        {
            CreateMap<Medico, MedicoDto>().ReverseMap();
        }
    }
}
