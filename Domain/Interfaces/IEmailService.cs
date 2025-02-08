using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Dispara email paciente
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task SendEmailAsync(string to, string subject, string body);
    }
}
