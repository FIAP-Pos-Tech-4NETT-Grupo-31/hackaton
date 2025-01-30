using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


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

        public string GetPacienteToken(string email, string senha)
        {
            var paciente = _authenticationRepository.GetPacienteCredentials(email, senha);

            if (paciente == null) return string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var chaveCriptografia = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Email, email),
               }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(
                   new SymmetricSecurityKey(chaveCriptografia),
                   SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);
            return tokenHandler.WriteToken(token);
        }
    }
}
