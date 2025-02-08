using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Mappings
{
    public class PacienteMap : Profile
    {
        public PacienteMap()
        {
            CreateMap<Paciente, PacienteDto>().ReverseMap();
        }
    }
}
