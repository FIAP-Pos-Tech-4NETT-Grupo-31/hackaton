
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System.Data;

namespace YourProject.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DapperDbContext _dbContext;

        public PacienteRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Paciente> GetAll()
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = "SELECT Id, Nome, Email, CPF FROM Paciente";
                var result = connection.Query<Paciente>(query);
                return result;
            }
        }
    }
}
