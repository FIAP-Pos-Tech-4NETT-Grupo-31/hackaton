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
        public async Task<IActionResult> Post([FromBody] PacienteRequest pacienteRequest)
        {
            var pacienteDTO = new Paciente()
            {
                Email = pacienteRequest.Email,
                Senha = pacienteRequest.Senha,
                CPF = pacienteRequest.CPF,
                Nome = pacienteRequest.Nome,
                DataNascimento = pacienteRequest.DataNascimento,
                Telefone = pacienteRequest.Telefone
            };
            var novoPaciente = await _pacienteService.AddPaciente(pacienteDTO);
            return Created(string.Empty, novoPaciente);
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
