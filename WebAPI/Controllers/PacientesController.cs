using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Requests;
using System.Security.Claims;
using Domain.Dtos;

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
        public async Task<IEnumerable<PacienteDto>> GetAll()
        {
            var pacientes = await _pacienteService.GetAllPacientes();
            return pacientes;
        }

        [Authorize]
        [HttpGet("{pacienteId}")]
        public async Task<PacienteDto?> GetPacienteById(int pacienteId)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var paciente = await _pacienteService.GetPacienteById(pacienteId);
            return paciente;
        }
                
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PacienteRequest pacienteRequest)
        {
            var pacienteDTO = new PacienteDto()
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
            return Ok(await _pacienteService.DeletePaciente(pacienteId));
        }

        [Authorize]
        [HttpGet]
        [Route("{pacienteId}/Consultas")]
        public async Task<IEnumerable<AgendaDto>> GetPacienteConsultas([FromRoute] int pacienteId)
        {
            return await _pacienteService.GetConsultasPaciente(pacienteId);
        }
    }
}
