using Application.Interfaces;
using Domain.Dtos;
using Domain.Interfaces;

namespace Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository) => _medicoRepository = medicoRepository;

        public async Task<IList<MedicoDto>> GetAll()
        {
            return await _medicoRepository.GetAllMedicos();
        }

        public async Task<MedicoDto> GetMedicoById(int medicoId)
        {
            return await _medicoRepository.GetMedicoById(medicoId);
        }

        public async Task<int> AddMedico(MedicoDto medico)
        {
            return await _medicoRepository.AddMedico(medico);
        }

        public async Task<int> AlterMedico(int id, MedicoDto medico)
        {
            return await _medicoRepository.AlterMedico(id, medico);
        }

        public async Task<int> DeleteMedicoById(int id)
        {
            return await _medicoRepository.DeleteMedicoById(id);
        }
    }
}
