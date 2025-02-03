using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Text;

namespace Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;            
        }

        public IEnumerable<Paciente> GetAllPacientes()
        {
            var result = _pacienteRepository.GetAll();
            return result;
        }

        public Paciente? GetPacienteById(int idPaciente)
        {
            var result = _pacienteRepository.GetPacienteById(idPaciente);
            return result;
        }

        public async Task<Paciente> AddPaciente(Paciente paciente)
        {
            paciente.Senha = Convert.ToBase64String(Encoding.UTF8.GetBytes(paciente.Senha));
            return await _pacienteRepository.AddPaciente(paciente);
        }

        public async Task<int> DeletePaciente(int idPaciente)
        {
            return await _pacienteRepository.DeletePaciente(idPaciente);
        }

        public Paciente GetPacienteByMail(string mail)
        {
            var paciente = _pacienteRepository.GetPacienteByMail(mail);
            return paciente;
        }
    }
}
