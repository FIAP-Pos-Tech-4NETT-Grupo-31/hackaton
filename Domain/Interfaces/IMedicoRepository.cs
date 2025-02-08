using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMedicoRepository
    {
        /// <summary>
        /// Busca todos os médicos cadastrados
        /// </summary>
        /// <returns></returns>
        Task<IList<MedicoDto>> GetAllMedicos();

        /// <summary>
        /// Busca médico por id 
        /// </summary>
        /// <param name="medicoId"></param>
        /// <returns></returns>
        Task<MedicoDto> GetMedicoById(int medicoId);

        /// <summary>
        /// persiste médico
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        Task<int> AddMedico(MedicoDto medico);

        /// <summary>
        /// Atualiza cadastro médico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medico"></param>
        /// <returns></returns>
        Task<int> AlterMedico(int id, MedicoDto medico);

        /// <summary>
        /// Exclui médico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteMedicoById(int id);

        /// <summary>
        /// Atualiza agenda do médico
        /// </summary>
        /// <param name="idMedico"></param>
        /// <param name="horarioMedico"></param>
        /// <returns></returns>
        Task<int> UpdateMedicoSchedule(int medicoId, string novoHorarioMedico);

        /// <summary>
        /// Busca consultas do médico
        /// </summary>
        /// <param name="idMedico"></param>
        /// <returns></returns>
        Task<IEnumerable<AgendaDto>> GetPendingConsultasAsync(int idMedico);
    }
}
