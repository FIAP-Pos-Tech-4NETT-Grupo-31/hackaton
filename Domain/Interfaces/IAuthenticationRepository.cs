using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Credentials? GetCredentials(string email, string senha, Roles role);
    }
}
