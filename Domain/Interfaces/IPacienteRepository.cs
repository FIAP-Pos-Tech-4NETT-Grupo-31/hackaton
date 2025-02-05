using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente> GetAll();
        Paciente? GetPacienteById(int idPaciente);
        Task<Paciente> AddPaciente(Paciente paciente);
        Task<int> DeletePaciente(int idPaciente);
        Paciente? GetPacienteByMail(string mail);
        IEnumerable<Agenda> GetConsultasPaciente(int idPaciente);
    }
}
