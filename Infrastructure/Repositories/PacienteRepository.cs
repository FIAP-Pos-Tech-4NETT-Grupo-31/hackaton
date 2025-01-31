
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System.Data;
using System.Data.Common;

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

        public async Task<Paciente> AddPaciente(Paciente paciente)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = @"INSERT INTO Paciente (Nome, Email, Telefone, CPF, Senha, DataNascimento) 
                                 VALUES (@Nome, @Email, @Telefone, @CPF, @Senha, @DataNascimento)";
                var id = await connection.ExecuteAsync(query, paciente);
                paciente.Id = id;
                return paciente;
            }    
        }
    }
}
