using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebAPI.Models.Requests;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;        
        public MedicoController(IMedicoService medicoService) => _medicoService = medicoService;

        [HttpGet]
        [Authorize]
        public async Task<IList<MedicoDto>> GetAllMedicos() 
            => await _medicoService.GetAll();     
        
        [HttpGet("{medicoId}")]
        [Authorize]
        public async Task<MedicoDto> GetMedicoByid(int medicoId) 
            => await _medicoService.GetMedicoById(medicoId);

        [HttpPost]
        [Authorize]
        public async Task<int> AddMedico([FromBody] MedicoDto medico)
            => await _medicoService.AddMedico(medico);

        [HttpPut]
        [Authorize]
        public async Task<int> AlterMedico([FromQuery] int medicoId, MedicoDto medico)
            => await _medicoService.AlterMedico(medicoId, medico);

        [HttpDelete]
        [Authorize]
        public async Task<int> DeleteMedico(int medicoId)
            => await _medicoService.DeleteMedicoById(medicoId);

        [HttpPut("/update_agenda_medico")]
        [Authorize]
        public async Task<int> UpdateMedicoSchedule([FromQuery] int medicoId, HorarioMedicoRequest novoHorario)
        {
            var horarioMedico = new HorarioMedico();
            horarioMedico.DuracaoConsulta = novoHorario.DuracaoConsulta.ToString();
            horarioMedico.Dom = (novoHorario.DomInit != null && Regex.IsMatch(novoHorario.DomInit, @"^\d{2}:\d{2}$")) && (novoHorario.DomEnd != null && Regex.IsMatch(novoHorario.DomEnd, @"^\d{2}:\d{2}$")) ?
                $"{novoHorario.DomInit}-{novoHorario.DomEnd}" :
                null;
            horarioMedico.Seg = (novoHorario.SegInit != null && Regex.IsMatch(novoHorario.SegInit, @"^\d{2}:\d{2}$")) && (novoHorario.SegEnd != null && Regex.IsMatch(novoHorario.SegEnd, @"^\d{2}:\d{2}$")) ? 
                $"{novoHorario.SegInit}-{novoHorario.SegEnd}" : 
                null;
            horarioMedico.Ter = (novoHorario.TerInit != null && Regex.IsMatch(novoHorario.TerInit, @"^\d{2}:\d{2}$")) && (novoHorario.TerEnd != null && Regex.IsMatch(novoHorario.TerEnd, @"^\d{2}:\d{2}$")) ? 
                $"{novoHorario.TerInit}-{novoHorario.TerEnd}" : 
                null;
            horarioMedico.Qua = (novoHorario.QuaInit != null && Regex.IsMatch(novoHorario.QuaInit, @"^\d{2}:\d{2}$")) && (novoHorario.QuaEnd != null && Regex.IsMatch(novoHorario.QuaEnd, @"^\d{2}:\d{2}$")) ?
                $"{novoHorario.QuaInit}-{novoHorario.QuaEnd}" :
                null;
            horarioMedico.Qui = (novoHorario.QuiInit != null && Regex.IsMatch(novoHorario.QuiInit, @"^\d{2}:\d{2}$")) && (novoHorario.QuiEnd != null && Regex.IsMatch(novoHorario.QuiEnd, @"^\d{2}:\d{2}$")) ?
                $"{novoHorario.QuiInit}-{novoHorario.QuiEnd}" :
                null;
            horarioMedico.Sex = (novoHorario.SexInit != null && Regex.IsMatch(novoHorario.SexInit, @"^\d{2}:\d{2}$")) && (novoHorario.SexEnd != null && Regex.IsMatch(novoHorario.SexEnd, @"^\d{2}:\d{2}$")) ?
                $"{novoHorario.SexInit}-{novoHorario.SexEnd}" :
                null;
            horarioMedico.Sab = (novoHorario.SabInit != null && Regex.IsMatch(novoHorario.SabInit, @"^\d{2}:\d{2}$")) && (novoHorario.SabEnd != null && Regex.IsMatch(novoHorario.SabEnd, @"^\d{2}:\d{2}$")) ?
                $"{novoHorario.SabInit}-{novoHorario.SabEnd}" :
                null;

            var result = await _medicoService.UpdateMedicoSchedule(medicoId, horarioMedico);
            return result;
        }

        [HttpGet("/get_pending_consultas")]
        [Authorize]
        public async Task<IEnumerable<Agenda>> GetPendingConsultas([FromQuery] int medicoId)
        {
            var consultas = _medicoService.GetPendingConsultas(medicoId);
            return consultas;
        }
    }
}
