using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPacienteRepository
    {
        public IEnumerable<Paciente> GetAll();
        public Paciente? GetPacienteById(int idPaciente);
        public Task<Paciente> AddPaciente(Paciente paciente);
        public Task<int> DeletePaciente(int idPaciente);
        public int? GetIdByMail(string mail);
    }
}
