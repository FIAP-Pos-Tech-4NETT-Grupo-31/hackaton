namespace WebAPI.Models.Requests
{
    public class CredentialRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class CredentialMedicoRequest
    {
        public string CRMOuEmail { get; set; }

        public string Senha { get; set; }
    }
}
