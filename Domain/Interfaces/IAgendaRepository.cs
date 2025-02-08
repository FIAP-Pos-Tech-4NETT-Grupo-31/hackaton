using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAgendaRepository
    {
        /// <summary>
        /// Busca agendamento do dia ao qual deseja marcar consulta
        /// </summary>
        /// <param name="idMedico"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerable<Agenda> MedicoDailyAppointments(int idMedico, DateTime date);

        /// <summary>
        /// Adiciona marcação na agenda 
        /// </summary>
        /// <param name="idMedico"></param>
        /// <param name="idPaciente"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public Task<bool> AddAppointment(int idMedico, int idPaciente, DateTime date);

        /// <summary>
        /// Aprova consulta
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <returns></returns>
        public Task<int> ApproveConsulta(int idConsulta);

        /// <summary>
        /// Deleta consulta
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <returns></returns>
        public Task<int> DeleteConsulta(int idConsulta);
    }
}
