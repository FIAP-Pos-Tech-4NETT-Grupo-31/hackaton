using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPacienteService
    {
        /// <summary>
        /// Busca todos os pacientes cadastrados.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PacienteDto>> GetAllPacientes();

        /// <summary>
        /// Busca paciente por id 
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        Task<PacienteDto?> GetPacienteById(int idPaciente);

        /// <summary>
        /// Cadastra paciente
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        Task<PacienteDto> AddPaciente(PacienteDto paciente);

        /// <summary>
        /// Deleta paciente
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        Task<int> DeletePaciente(int idPaciente);

        /// <summary>
        /// Busca paciente por login
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        Task<PacienteDto> GetPacienteByMail(string mail);

        /// <summary>
        /// Busca agenda do paciente
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        Task<IEnumerable<AgendaDto>> GetConsultasPaciente(int idPaciente);
    }
}
