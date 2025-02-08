using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IList<MedicoDto>> GetAllMedicos();
        Task<MedicoDto> GetMedicoById(int medicoId);
        Task<int> AddMedico(MedicoDto medico);
        Task<int> AlterMedico(int id, MedicoDto medico);
        Task<int> DeleteMedicoById(int id);
        Task<int> UpdateMedicoSchedule(int medicoId, string novoHorarioMedico);
        Task<IEnumerable<AgendaDto>> GetPendingConsultasAsync(int idMedico);
    }
}
