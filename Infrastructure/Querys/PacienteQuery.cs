namespace Infrastructure.Querys
{
    public class PacienteQuery
    {
        public const string GetAll = 
            "SELECT " +
            "Id, " +
            "Nome, " +
            "Email, " +
            "CPF " +
            "FROM Paciente";

        public const string GetPacienteById = @"
            SELECT 
                Id,
                Nome,
                Email,
                CPF
            FROM Paciente 
            WHERE Id = @Id"
        ;

        public const string AddPaciente = @"
            INSERT INTO Paciente 
                    (
                    Nome,
                    Email, 
                    Telefone, 
                    CPF, 
                    Senha, 
                    DataNascimento
                    ) 
            VALUES (
                    @Nome,
                    @Email, 
                    @Telefone, 
                    @CPF, 
                    @Senha,
                    @DataNascimento
                    )"
        ;

        public const string DeletePaciente = @"
            DELETE FROM Paciente 
            WHERE Id = @Id"
        ;

        public const string GetPacienteByMail = @"
            SELECT 
                Id,
                Nome,
                Email,
                CPF
            FROM Paciente 
            WHERE Email = @Email"
        ;

        public const string GetConsultasPaciente = @"
            SELECT 
                    Id,
                    IdMedico, 
                    IdPaciente, 
                    DataConsulta,
                    Status 
                FROM Agenda 
                WHERE IdPaciente = @IdPaciente"
        ;
    }
}
