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
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _map;
        private readonly DapperDbContext _dbContext;

        public PacienteRepository(DapperDbContext dbContext, IDbConnection dbConnection, IMapper map)
        {
            _dbConnection = dbConnection;
            _map = map;
            _dbContext = dbContext;
        }        

        public async Task<IEnumerable<PacienteDto>> GetAll()
        {
            var pacienteList = await _dbConnection.QueryAsync<Paciente>(PacienteQuery.GetAll);
            return _map.Map<IEnumerable<PacienteDto>>(pacienteList.ToList());
        }

        public async Task<PacienteDto>? GetPacienteById(int idPaciente)
        {
            var paciente = await _dbConnection.QueryFirstOrDefaultAsync<Paciente>(
                            PacienteQuery.GetPacienteById, new { Id = idPaciente });

            return _map.Map<PacienteDto>(paciente);
        }

        public async Task<PacienteDto> AddPaciente(PacienteDto paciente)
        {
            _ = await _dbConnection.ExecuteAsync(PacienteQuery.AddPaciente, new
            {
                paciente.Nome,
                paciente.DataNascimento,
                paciente.CPF,
                paciente.Telefone,
                paciente.Senha,
                paciente.Email
            });

            return paciente;
        }

        public async Task<int> DeletePaciente(int idPaciente)
        {
            return await _dbConnection.ExecuteAsync(PacienteQuery.DeletePaciente, new { Id = idPaciente });
        }

        public async Task<PacienteDto> GetPacienteByMail(string mail)
        {
            var paciente = await _dbConnection.QueryFirstOrDefaultAsync<Paciente>(PacienteQuery.GetPacienteByMail, new { Email = mail });
            return _map.Map<PacienteDto>(paciente);
        }
        
        public async Task<IEnumerable<AgendaDto>> GetConsultasPaciente(int idPaciente)
        {
            var consulta = await _dbConnection.QueryAsync<Agenda>(PacienteQuery.GetConsultasPaciente, new { IdPaciente = idPaciente });
            return _map.Map<IEnumerable<AgendaDto>>(consulta);
        }
    }
}
