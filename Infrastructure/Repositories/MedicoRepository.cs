using AutoMapper;
using Dapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Querys;
using System.Data;

namespace hackaton.Infrastructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _map;

        public MedicoRepository(IDbConnection dbConnection, IMapper map)
        {
            _dbConnection = dbConnection;
            _map = map;
        }

        public async Task<IList<MedicoDto>> GetAllMedicos()
        {
            var MedicosList = await _dbConnection.QueryAsync<Medico>(MedicoQuery.GetAll);
            return _map.Map<IList<MedicoDto>>(MedicosList.ToList());
        }

        public async Task<MedicoDto> GetMedicoById(int medicoId)
        {
            var medico = await _dbConnection.QueryFirstOrDefaultAsync<Medico>(
            MedicoQuery.GetMedicoById, new { Id = medicoId });

            return _map.Map<MedicoDto>(medico);
        }

        public async Task<int> AddMedico(MedicoDto medico)
        {
            return await _dbConnection.ExecuteAsync(MedicoQuery.AddMedico, new
            {
                medico.Nome,
                medico.Especialidade,
                medico.Crm,
                medico.Telefone,
                medico.Email
            });
        }

        public async Task<int> AlterMedico(int id, MedicoDto medico)
        {
            return await _dbConnection.ExecuteAsync(MedicoQuery.AlterMedico, new
            {
                medico.Nome,
                medico.Especialidade,
                medico.Crm,
                medico.Telefone,
                medico.Email,
                Id = id
            });
        }

        public async Task<int> DeleteMedicoById(int id)
        {
            return await _dbConnection.ExecuteAsync(MedicoQuery.DeleteMedico, new { Id = id });
        }
    }
}
