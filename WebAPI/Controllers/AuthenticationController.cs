using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Requests;
using Domain.Enum;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService AuthenticationService) {
            _authenticationService = AuthenticationService;
        }

        [HttpPost]
        [Route("Paciente")]
        public IActionResult AutenthicatePaciente([FromBody] CredentialRequest credencial)
        {
            var token = _authenticationService.GetToken(credencial.Email, credencial.Senha, Roles.Paciente);

            if (!string.IsNullOrWhiteSpace(token)) return Ok(token);

            return Unauthorized();
        }
        
        [HttpPost]
        [Route("Medico")]
        public IActionResult AutenthicateMedico([FromBody] CredentialMedicoRequest credencial)
        {
            var token = _authenticationService.GetToken(credencial.CRMOuEmail, credencial.Senha, Roles.Medico);

            if (!string.IsNullOrWhiteSpace(token)) return Ok(token);

            return Unauthorized();
        }
    }
}
