
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System.Data;

namespace YourProject.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DapperDbContext _dbContext;

        public AuthenticationRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Credentials? GetPacienteCredentials(string email, string senha) {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = "SELECT Email, Senha FROM Paciente WHERE Email = @Email AND Senha = @Senha";
                var parametros = new { Email = email, Senha = senha };
                var result = connection.Query<Credentials>(query, parametros);
                return result.FirstOrDefault();
            }
        }
    }
}
