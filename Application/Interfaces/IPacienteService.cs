using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente? GetPacienteById(int idPaciente);
        Task<Paciente> AddPaciente(Paciente paciente);
        Task<int> DeletePaciente(int idPaciente);
        Paciente? GetPacienteByMail(string mail);
        IEnumerable<Agenda> GetConsultasPaciente(int idPaciente);
    }
}
