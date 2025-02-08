using Application.Interfaces;
using Domain.Dtos;
using Domain.Interfaces;
using System.Text;

namespace Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository) => _medicoRepository = medicoRepository;

        public async Task<IList<MedicoDto>> GetAll()
        {
            return await _medicoRepository.GetAllMedicos();
        }

        public async Task<MedicoDto> GetMedicoById(int medicoId)
        {
            return await _medicoRepository.GetMedicoById(medicoId);
        }

        public async Task<int> AddMedico(MedicoDto medico)
        {
            medico.Senha = Convert.ToBase64String(Encoding.UTF8.GetBytes(medico.Senha));
            return await _medicoRepository.AddMedico(medico);
        }

        public async Task<int> AlterMedico(int id, MedicoDto medico)
        {
            return await _medicoRepository.AlterMedico(id, medico);
        }

        public async Task<int> DeleteMedicoById(int id)
        {
            return await _medicoRepository.DeleteMedicoById(id);
        }

        public async Task<int> UpdateMedicoSchedule(int idMedico, HorarioMedico horarioMedico)
        {
            var newHorarioMedico = $"Dur:{horarioMedico.DuracaoConsulta};";
            newHorarioMedico += horarioMedico.Dom != null ? $"Dom_{horarioMedico.Dom};" : "";
            newHorarioMedico += horarioMedico.Seg != null ? $"Seg_{horarioMedico.Seg};" : "";
            newHorarioMedico += horarioMedico.Ter != null ? $"Ter_{horarioMedico.Ter};" : "";
            newHorarioMedico += horarioMedico.Qui != null ? $"Qui_{horarioMedico.Qui};" : "";
            newHorarioMedico += horarioMedico.Qua != null ? $"Qua_{horarioMedico.Qua};" : "";
            newHorarioMedico += horarioMedico.Sex != null ? $"Sex_{horarioMedico.Sex};" : "";
            newHorarioMedico += horarioMedico.Sab != null ? $"Sab_{horarioMedico.Sab};" : "";

            var result = await _medicoRepository.UpdateMedicoSchedule(idMedico, newHorarioMedico);
            return result;
        }

        public async Task<IEnumerable<AgendaDto>> GetPendingConsultas(int idMedico)
        {
            var consultas = await _medicoRepository.GetPendingConsultasAsync(idMedico);
            return consultas;
        }
    }    
}
