using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAgendaRepository
    {
        public IEnumerable<Agenda> MedicoDailyAppointments(int idMedico, DateTime date);
        public Task<bool> AddAppointment(int idMedico, int idPaciente, DateTime date);        
    }
}
