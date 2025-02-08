using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IConsultaService
    {
        /// <summary>
        /// Busca horarios vinculados ao médico
        /// </summary>
        /// <param name="idMedico">identificador  médico</param>
        /// <returns></returns>
        Task<HorarioMedico?> GetHorariosMedico(int idMedico);

        /// <summary>
        /// Verifica agenda do médico
        /// </summary>
        /// <param name="scheduleMedico">Data para marcar horário</param>
        /// <param name="idMedico">identificador  médico</param>
        /// <param name="userEmail">email user</param>
        /// <returns></returns>
        Task<bool> ScheduleWithMedico(DateTime scheduleMedico, int idMedico, string userEmail);

        /// <summary>
        /// Aprova a consulta médica
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <param name="approveOrReprove"></param>
        /// <returns></returns>
        Task<bool> ApproveOrDeleteConsulta(int idConsulta, bool approveOrReprove);
    }
}
