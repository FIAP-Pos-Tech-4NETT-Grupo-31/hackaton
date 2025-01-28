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
        public PacienteController(IPacienteService pacienteService) {
            _pacienteService = pacienteService;
        }
        [HttpGet]
        public IEnumerable<Paciente> Get()
        {
            var pacientes = _pacienteService.GetPaciente();
            return pacientes;
        }
    }
}
