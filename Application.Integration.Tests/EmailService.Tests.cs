using Domain.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace Application.Integration.Tests
{
    [TestFixture]
    [Ignore("Desabilitado temporariamente")]
    public class EmailServiceTests
    {
        private IEmailService _emailService;

        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"EmailSettings:SmtpServer", "smtp.example.com"},
                {"EmailSettings:Port", "587"},
                {"EmailSettings:Username", "your-email@example.com"},
                {"EmailSettings:Password", "your-email-password"},
                {"EmailSettings:EnableSsl", "true"},
                {"EmailSettings:From", "your-email@example.com"}
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
            var to = "recipient@example.com";
            var subject = "Test Email";
            var body = "This is a test email.";

            // Act
            await _emailService.SendEmailAsync(to, subject, body);

            // Assert
            // Verificar manualmente se o e-mail foi enviado
        }
    }
}