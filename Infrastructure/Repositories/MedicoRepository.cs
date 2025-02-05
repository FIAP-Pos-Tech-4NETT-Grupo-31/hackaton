using AutoMapper;
using Dapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Querys;
using System.Data;

namespace hackaton.Infrastructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _map;
        private readonly DapperDbContext _dbContext;

        public MedicoRepository(IDbConnection dbConnection, IMapper map, DapperDbContext dapperDbContext)
        {
            _dbConnection = dbConnection;
            _map = map;
            _dbContext = dapperDbContext;
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

        public async Task<int> UpdateMedicoSchedule(int medicoId, string novoHorarioMedico)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = @"UPDATE Medico set Horarios = @Horarios WHERE Id = @Id";
                var result = await connection.ExecuteAsync(query, new { Horarios = novoHorarioMedico, Id = medicoId});
                return result;
            }
        }

        public IEnumerable<Agenda> GetPendingConsultas(int idMedico)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = @"Select Id, IdMedico, IdPaciente, DataConsulta, Status FROM Agenda WHERE IdMedico = @IdMedico and Status = 'Solicitado'";
                var result = connection.Query<Agenda>(query, new { IdMedico = idMedico });
                return result;
            }
        }
    }
}
