using Domain.Enum;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        public string GetToken(string email, string senha, Roles role);
    }
}
