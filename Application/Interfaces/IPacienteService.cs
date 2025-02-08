using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> GetAllPacientes();
        Task<PacienteDto?> GetPacienteById(int idPaciente);
        Task<PacienteDto> AddPaciente(PacienteDto paciente);
        Task<int> DeletePaciente(int idPaciente);
        Task<PacienteDto> GetPacienteByMail(string mail);
        Task<IEnumerable<AgendaDto>> GetConsultasPaciente(int idPaciente);
    }
}
