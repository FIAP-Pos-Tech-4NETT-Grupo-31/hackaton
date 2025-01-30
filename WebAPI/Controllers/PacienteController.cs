using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Requests;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IAuthenticationService _authenticationService;
        public PacienteController(IPacienteService pacienteService, IAuthenticationService authenticationService)
        {
            _pacienteService = pacienteService;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        public IEnumerable<Paciente> Get()
        {
            var pacientes = _pacienteService.GetPaciente();
            return pacientes;
        }
        
        [HttpPost]
        [Route("authentication")]
        public IActionResult AutenthicatePaciente([FromBody] CredentialRequest credencial)
        {
            var token = _authenticationService.GetPacienteToken(credencial.Email, credencial.Senha);

            if (!string.IsNullOrWhiteSpace(token)) return Ok(token);
            
            return Unauthorized();
        }
    }
}
