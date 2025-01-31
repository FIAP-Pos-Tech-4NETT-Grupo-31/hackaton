using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPacienteRepository
    {
        public IEnumerable<Paciente> GetAll();

        public Task<Paciente> AddPaciente(Paciente paciente);
    }
}
