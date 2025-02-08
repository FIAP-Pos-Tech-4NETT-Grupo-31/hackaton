using Application.Interfaces;
using Application.Services;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace Application.Unit.Tests.Services
{
    public class MedicoServiceTests
    {
        private IMedicoService _medicoService;
        private Mock<IMedicoRepository> _mockMedicoRepository;

        private readonly List<MedicoDto> _mockListaDeMedicos = new()
       {
            new(){
                Nome = "John Doe",
                Especialidade = "Cardiologista",
                Crm = "123456",
                Telefone = "1234567890",
                Email = "john.doe@email.com",
                DataCriacao = new DateTime(2021, 1, 1),
                Horarios = "Dur:30;Seg_09:00-18:00;Ter_09:00-18:00;Qua_09:00-18:00;Qui_09:00-18:00;Sex_09:00-18:00;",
                Id = 1,
                Senha = "ncienciekcd"
            },
            new(){
                Nome = "Jane Doe",
                Especialidade = "Pediatra",
                Crm = "654321",
                Telefone = "0987654321",
                Email = "jane.doe@email.com",
                DataCriacao = new DateTime(2021, 2, 2),
                Horarios = "Dur:30;Seg_09:00-18:00;Ter_09:00-18:00;Qua_09:00-18:00;Qui_09:00-18:00;Sex_09:00-18:00;",
                Id = 1,
                Senha = "ncienciekcd"
            }
       };

        private MedicoDto BuildMedicoDto()
        {
            // Arrange
            return new MedicoDto
            {
                Nome = _mockListaDeMedicos.First().Nome,
                Especialidade = _mockListaDeMedicos.First().Especialidade,
                Crm = _mockListaDeMedicos.First().Crm,
                Telefone = _mockListaDeMedicos.First().Telefone,
                Email = _mockListaDeMedicos.First().Email,
                DataCriacao = _mockListaDeMedicos.First().DataCriacao
            };
        }

        [SetUp]
        public void Setup()
        {
            _mockMedicoRepository = new Mock<IMedicoRepository>();
            _medicoService = new MedicoService(_mockMedicoRepository.Object);
        }

        [Test]
        public async Task Deve_Retornar_Lista_De_Medicos()
        {
            // Arrange
            _mockMedicoRepository
                .Setup(x => x.GetAllMedicos())
                .ReturnsAsync(_mockListaDeMedicos);

            // Act
            var result = await _medicoService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task Deve_Adicionar_Medico()
        {
            MedicoDto medicoDto = BuildMedicoDto();

            // Act
            var result = _medicoService.AddMedico(medicoDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Deve_Alterar_Medico()
        {
            // Arrange
            var medicoDto = BuildMedicoDto();

            // Act
            var result = _medicoService.AlterMedico(1, medicoDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Deve_Deletar_Medico()
        {
            // Arrange
            var medicoId = 1;

            // Act
            var result = _medicoService.DeleteMedicoById(medicoId);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
