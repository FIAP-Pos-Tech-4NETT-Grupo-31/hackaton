using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

public class PacienteServiceTests
{
    private IPacienteService pacienteService;
    private Mock<IPacienteRepository> _mockPacienteRepository;

    private readonly List<Paciente> _mockListaDePacientes = new()
    {
        new Paciente { Id = 1, Nome = "John Doe", DataNascimento = new DateTime(1990, 1, 1), Email = "john.doe@example.com", Telefone = "1234567890", CPF = "12345678901", Senha = "password123" },
        new Paciente { Id = 2, Nome = "Jane Doe", DataNascimento = new DateTime(1992, 2, 2), Email = "jane.doe@example.com", Telefone = "0987654321", CPF = "10987654321", Senha = "password456" }
    };

    [SetUp]
    public void Setup()
    {
        _mockPacienteRepository = new Mock<IPacienteRepository>();
        pacienteService = new PacienteService(_mockPacienteRepository.Object);
    }

    [Test]
    public async Task Deve_Retornar_Lista_De_Pacientes()
    {
        // Arrange
        _mockPacienteRepository
            .Setup(x => x.GetAll())
            .Returns(_mockListaDePacientes);

        // Act
        var result = pacienteService.GetPaciente();

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public async Task Deve_Adicionar_Paciente()
    {
        // Arrange
        var novoPaciente = new Paciente
        {
            Nome = "João da silva",
            DataNascimento = new DateTime(1990, 1, 1),
            Email = "joao@email.com",
            Telefone = "1234567890",
            CPF = "12345678901",
            Senha = "password123",
        };

        _mockPacienteRepository
            .Setup(x => x.AddPaciente(novoPaciente))
            .ReturnsAsync(novoPaciente);

        // Act
        var result = await pacienteService.AddPaciente(novoPaciente);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.Nome, Is.EqualTo(novoPaciente.Nome));
    }
}