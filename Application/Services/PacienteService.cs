using Application.Interfaces;
using AutoMapper;
using Domain.Dtos;
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

        public async Task<IEnumerable<PacienteDto>> GetAllPacientes()
        {
            var result = await _pacienteRepository.GetAll();
            return result;
        }

        public async Task<PacienteDto?> GetPacienteById(int idPaciente)
        {
            var result = await _pacienteRepository.GetPacienteById(idPaciente);
            return result;
        }

        public async Task<PacienteDto> AddPaciente(PacienteDto paciente)
        {
            paciente.Senha = Convert.ToBase64String(Encoding.UTF8.GetBytes(paciente.Senha));
            return await _pacienteRepository.AddPaciente(paciente);
        }

        public async Task<int> DeletePaciente(int idPaciente)
        {
            return await _pacienteRepository.DeletePaciente(idPaciente);
        }

        public async Task<PacienteDto> GetPacienteByMail(string mail)
        {
            var paciente = await _pacienteRepository.GetPacienteByMail(mail);
            return paciente;
        }

        public async Task<IEnumerable<AgendaDto>> GetConsultasPaciente(int idPaciente)
        {
            return await _pacienteRepository.GetConsultasPaciente(idPaciente);
        }
    }
}
