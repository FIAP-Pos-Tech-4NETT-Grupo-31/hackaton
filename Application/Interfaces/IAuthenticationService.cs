using Domain.Enum;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Busca token autorização
        /// </summary>
        /// <param name="email">email user</param>
        /// <param name="senha">senha user</param>
        /// <param name="role">medico/paciente</param>
        /// <returns></returns>
        public string GetToken(string email, string senha, Roles role);
    }
}
