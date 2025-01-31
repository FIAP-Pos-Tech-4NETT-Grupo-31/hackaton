using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Domain.Enum;


namespace Application.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IConfiguration configuration, IAuthenticationRepository authenticationRepository) {
            _configuration = configuration;
            _authenticationRepository= authenticationRepository;
        }

        public string GetToken(string email, string senha, Roles role)
        {
            var senhaBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(senha));
            var credenciais = _authenticationRepository.GetCredentials(email, senhaBase64, role);
            if (credenciais == null) return string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var chaveSecreta = _configuration.GetValue<string>("SecretJWT");

            if (string.IsNullOrEmpty(chaveSecreta))
                throw new InvalidOperationException("Chave JWT não configurada corretamente.");

            var chaveCriptografia = Encoding.ASCII.GetBytes(chaveSecreta);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
            };

            var tokenPropriedades = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chaveCriptografia),
                    SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);
            return tokenHandler.WriteToken(token);
        }
    }
}
