using Application.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        public MedicoController(IMedicoService medicoService) => _medicoService = medicoService;

        [HttpGet]
        public async Task<IList<MedicoDto>> GetAllMedicos() 
            => await _medicoService.GetAll();     
        
        [HttpGet("{medicoId}")]
        public async Task<MedicoDto> GetMedicoByid(int medicoId) 
            => await _medicoService.GetMedicoById(medicoId);

        [HttpPost]
        public async Task<int> AddMedico([FromBody] MedicoDto medico)
            => await _medicoService.AddMedico(medico);

        [HttpPut]
        public async Task<int> AlterMedico([FromQuery] int medicoId, MedicoDto medico)
            => await _medicoService.AlterMedico(medicoId, medico);

        [HttpDelete]
        public async Task<int> DeleteMedico(int medicoId)
            => await _medicoService.DeleteMedicoById(medicoId);
    }
}
