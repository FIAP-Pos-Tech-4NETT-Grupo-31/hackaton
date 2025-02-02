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
        public Task<HorarioMedico?> GetHorariosMedico(int idMedico);
        public Task<bool> ScheduleWithMedico(DateTime scheduleMedico, int idMedico, string userEmail);
    }
}
