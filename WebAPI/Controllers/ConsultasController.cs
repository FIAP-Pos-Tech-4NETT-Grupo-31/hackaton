using Application.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPI.Models.Requests;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultasController(IConsultaService consultaService) {
            _consultaService = consultaService;
        }

        [HttpGet]
        [Route("Horarios/{medicoId}")]
        [Authorize]
        public async Task<HorarioMedico?> GetHorariosMedico(int medicoId)
        {
            var horarioMedico = await _consultaService.GetHorariosMedico(medicoId);
            return horarioMedico;
        }

        [HttpPost]
        [Route("Agendar")]
        [Authorize]
        public async Task<bool> ScheduleWithMedico(ScheduleMedico data)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = await _consultaService.ScheduleWithMedico(data.Date, data.IdMedico, userEmail);
            return result;
        }

        [HttpPost]
        [Route("Aprovar")]
        [Authorize]
        public async Task<bool> ApproveConsulta(AprovacaoRequest aprovacao)
        {
            var result = await _consultaService.ApproveOrDeleteConsulta(aprovacao.IdConsulta, aprovacao.Aprovar);
            return result;
        }
    }
}
