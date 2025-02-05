using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System.Data;

namespace Infrastructure.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly DapperDbContext _dbContext;

        public AgendaRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Agenda> MedicoDailyAppointments(int idMedico, DateTime date)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = $@"
                    SELECT Id, IdMedico, IdPaciente, DataConsulta, Descricao, Status
                    FROM agenda
                    WHERE IdMedico = @IdMedico
                    AND DataConsulta BETWEEN @StartDate AND @EndDate
                ";
                var result = connection.Query<Agenda>(query, new { IdMedico = idMedico, StartDate = date.ToString("yyyy-dd-MM"), EndDate = date.AddDays(1).ToString("yyyy-dd-MM") });
                return result;
            }                
        }

        public async Task<bool> AddAppointment(int idMedico, int idPaciente, DateTime date)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = @"INSERT INTO Agenda (IdMedico, IdPaciente, DataConsulta, Status) 
                                 VALUES (@IdMedico, @IdPaciente, @DataConsulta, @Status)";
                var result = await connection.ExecuteAsync(query, new { IdMedico = idMedico, IdPaciente = idPaciente, DataConsulta = date.ToString(), Status = "Solicitado"});
                return result > 0 ? true : false;
            }
        }

        public async Task<int> ApproveConsulta(int idConsulta)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = @"UPDATE Agenda SET Status = 'Agendado' WHERE Id = @Id";
                var result = await connection.ExecuteAsync(query, new { Id = idConsulta });
                return result;
            }
        }
        public async Task<int> DeleteConsulta(int idConsulta)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                string query = @"DELETE FROM Agenda WHERE Id = @Id";
                var result = await connection.ExecuteAsync(query, new { Id = idConsulta });
                return result;
            }
        }
    }
}
