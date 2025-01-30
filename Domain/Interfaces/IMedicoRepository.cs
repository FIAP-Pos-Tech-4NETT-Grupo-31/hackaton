using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IList<MedicoDto>> GetAllMedicos();
        Task<MedicoDto> GetMedicoById(int medicoId);
        Task<int> AddMedico(MedicoDto medico);
        Task<int> AlterMedico(int id, MedicoDto medico);
        Task<int> DeleteMedicoById(int id);
    }
}
