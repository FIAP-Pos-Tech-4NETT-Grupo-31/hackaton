using Application.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        
    }
}
