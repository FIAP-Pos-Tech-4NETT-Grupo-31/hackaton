using Domain.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace Application.Integration.Tests
{
    [TestFixture]
    [Ignore("Habilitar apenas quando for testar")]
    public class EmailServiceTests
    {
        private IEmailService _emailService;

        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"EmailSettings:SmtpServer", "live.smtp.mailtrap.io"},
                {"EmailSettings:Port", "587"},
                {"EmailSettings:Username", "smtp@mailtrap.io"},
                {"EmailSettings:Password", "8278d132e6cb9da4c4ad8fc16e45d557"},
                {"EmailSettings:EnableSsl", "true"},
                {"EmailSettings:From", "fiap.grupo31@demomailtrap.com"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _emailService = new EmailService(configuration);
        }

        [Test]
        public async Task SendEmailAsync_Deve_Enviar_Email()
        {
            // Arrange
            var to = "paulon0@yahoo.com.br";
            var subject = "Test Email";
            var body = "This is a test email.";

            // Act
            await _emailService.SendEmailAsync(to, subject, body);

            // Assert
            // Verificar manualmente se o e-mail foi enviado
        }
    }
}