using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Credentials? GetPacienteCredentials(string email, string senha);
    }
}
