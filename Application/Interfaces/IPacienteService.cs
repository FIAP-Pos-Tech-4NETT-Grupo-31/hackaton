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
        public IEnumerable<Paciente> GetAllPacientes();
        public Paciente? GetPacienteById(int idPaciente);
        public Task<Paciente> AddPaciente(Paciente paciente);
        public Task<int> DeletePaciente(int idPaciente);
        public int? GetIdByMail(string mail);
    }
}
