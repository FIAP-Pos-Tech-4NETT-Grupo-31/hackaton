using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Requests;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<Paciente> GetAll()
        {
            var pacientes = _pacienteService.GetAllPacientes();
            return pacientes;
        }

        [Authorize]
        [HttpGet("{pacienteId}")]
        public Paciente? GetPacienteById(int pacienteId)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var paciente = _pacienteService.GetPacienteById(pacienteId);
            return paciente;
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

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Put([FromBody] int pacienteId)
        {            
            var resultado = await _pacienteService.DeletePaciente(pacienteId);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("{pacienteId}/Consultas")]
        public IEnumerable<Agenda> GetPacienteConsultas([FromRoute] int pacienteId)
        {
            return _pacienteService.GetConsultasPaciente(pacienteId);
        }
    }
}
