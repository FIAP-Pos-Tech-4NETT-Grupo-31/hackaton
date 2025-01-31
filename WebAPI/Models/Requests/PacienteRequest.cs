using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Requests
{
    public class PacienteRequest
    {
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }    

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string CPF { get; set; }

        public string Senha { get; set; }
    }
}
