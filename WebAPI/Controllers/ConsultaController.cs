using Application.Interfaces;
using Application.Services;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPI.Models.Requests;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;
        public ConsultaController(IConsultaService consultaService) {
            _consultaService = consultaService;
        }

        [HttpGet("/agenda_medico")]
        [Authorize]
        public async Task<HorarioMedico?> GetHorariosMedico(int idMedico)
        {
            var horarioMedico = await _consultaService.GetHorariosMedico(idMedico);
            return horarioMedico;

        }

        [HttpPost("/agendar_consulta")]
        [Authorize]
        public async Task<bool> ScheduleWithMedico(ScheduleMedico data)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = await _consultaService.ScheduleWithMedico(data.Date, data.IdMedico, userEmail);
            return result;
        }
    }
}
