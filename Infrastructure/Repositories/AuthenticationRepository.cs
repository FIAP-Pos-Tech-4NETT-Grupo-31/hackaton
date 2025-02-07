
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

        public Credentials? GetCredentials(string login, string senha, Roles role)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = role == Roles.Paciente ?
                    $"SELECT Email, Senha FROM Paciente WHERE Email = @Login AND Senha = @Senha"
                    : $"SELECT Email, Senha FROM Medico WHERE (Email = @Login OR CRM = @Login) AND Senha = @Senha";
                var parametros = new { Login = login, Senha = senha };
                var result = connection.Query<Credentials>(query, parametros);
                return result.FirstOrDefault();
            }
        }       
    }
}
