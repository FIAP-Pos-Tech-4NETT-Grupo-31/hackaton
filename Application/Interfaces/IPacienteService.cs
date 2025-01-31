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
        public IEnumerable<Paciente> GetPaciente();

        public Task<Paciente> AddPaciente(Paciente paciente);
    }
}
