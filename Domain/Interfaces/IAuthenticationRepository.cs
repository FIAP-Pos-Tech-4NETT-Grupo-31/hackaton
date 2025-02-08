using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        /// <summary>
        /// Busca token
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public Credentials? GetCredentials(string email, string senha, Roles role);
    }
}
