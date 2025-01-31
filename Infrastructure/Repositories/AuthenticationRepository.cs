
using Dapper;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infrastructure.Context;
using System.Data;

namespace hackaton.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DapperDbContext _dbContext;

        public AuthenticationRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Credentials? GetCredentials(string email, string senha, Roles role)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string table = role == Roles.Paciente ? "Paciente" : "Medico";
                string query = $"SELECT Email, Senha FROM {table} WHERE Email = @Email AND Senha = @Senha";
                var parametros = new { Email = email, Senha = senha };
                var result = connection.Query<Credentials>(query, parametros);
                return result.FirstOrDefault();
            }
        }       
    }
}
