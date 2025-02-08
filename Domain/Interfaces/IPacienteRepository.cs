using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<PacienteDto>> GetAll();
        Task<PacienteDto>? GetPacienteById(int idPaciente);
        Task<PacienteDto> AddPaciente(PacienteDto paciente);
        Task<int> DeletePaciente(int idPaciente);
        Task<PacienteDto> GetPacienteByMail(string mail);
        Task<IEnumerable<AgendaDto>> GetConsultasPaciente(int idPaciente);
    }
}
