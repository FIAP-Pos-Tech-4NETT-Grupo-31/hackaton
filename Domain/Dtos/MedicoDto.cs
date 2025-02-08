namespace Domain.Dtos
{
    public class MedicoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Horarios{ get; set; }
        public string Senha { get; set; }
    }
}
