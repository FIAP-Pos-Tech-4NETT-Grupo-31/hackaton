using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
       
        public IEnumerable<Paciente> GetPaciente()
        {
            var result = _pacienteRepository.GetAll();
            return result;
        }

        public async Task<Paciente> AddPaciente(Paciente paciente)
        {
            return await _pacienteRepository.AddPaciente(paciente);
        }
    }
}
