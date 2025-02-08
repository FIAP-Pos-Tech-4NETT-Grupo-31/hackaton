namespace Infrastructure.Querys
{
    public class MedicoQuery
    {
        public const string GetAll = "SELECT * FROM Medico";
        
        public const string GetMedicoById = @"
                SELECT * FROM Medico 
                WHERE Id = @Id";
        
        public const string AddMedico = @"
                INSERT INTO [dbo].[Medico]
                            ([Nome]
                            ,[Especialidade]
                            ,[CRM]
                            ,[Telefone]
                            ,[Email]
                            ,[DataCriacao]
                            ,[Senha]
                            ,[Horarios])
                        VALUES
                            (@Nome,
                            @Especialidade,
                            @CRM,
                            @Telefone,
                            @Email,
                            @DataCriacao,
                            @Senha,
                            @Horarios)";

        public const string AlterMedico = @"
                UPDATE [dbo].[Medico]
                   SET [Nome] = @Nome
                      ,[Especialidade] = @Especialidade
                      ,[CRM] = @CRM
                      ,[Telefone] = @Telefone
                      ,[Email] = @Email
                 WHERE Id = @Id";

        public const string DeleteMedico = @"
                DELETE FROM [dbo].[Medico]
                      WHERE Id = @Id";

        public const string UpdateMedicoSchedule = @"
                UPDATE Medico 
                SET Horarios = @Horarios 
                WHERE Id = @Id";

        public const string GetPendingConsultas = @"
                Select Id, 
                        IdMedico,
                        IdPaciente,
                        DataConsulta, 
                        Status 
                FROM Agenda 
                WHERE IdMedico = @IdMedico and Status = 'Solicitado'";
    }
}
