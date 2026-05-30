using Moq;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;
using SpaceSense.Api.Repositories;
using SpaceSense.Api.Services;

namespace SpaceSense.Api.Tests.Services
{
    public class SateliteServiceTests
    {
        private readonly Mock<IRepository<Satelite>> _repositoryMock;
        private readonly SateliteService _service;

        public SateliteServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Satelite>>();
            _service = new SateliteService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetSatelitesAsync_DeveRetornarListaDeSatelites()
        {
            // Arrange
            var mockSatelites = new List<Satelite>
            {
                new Satelite { Id = 1, SateliteNome = "Hubble", EmpresaId = 1, OrbitaId = 1 },
                new Satelite { Id = 2, SateliteNome = "Starlink", EmpresaId = 2, OrbitaId = 2 }
            };

            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockSatelites);

            // Act
            var resultado = await _service.GetSatelitesAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal("Hubble", resultado.First().SateliteNome);
            _repositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateSateliteAsync_DeveSalvarERetornarSatelite()
        {
            // Arrange
            var request = new SateliteRequestDTO
            {
                SateliteNome = "Sputnik",
                SateliteFuncao = "Comunicação",
                SateliteStatus = "Ativo",
                SateliteDataLancamento = new DateTime(1957, 10, 4),
                SateliteVelocidade = 29000,
                EmpresaId = 1,
                OrbitaId = 1
            };

            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Satelite>())).Returns(Task.CompletedTask);

            // Act
            var resultado = await _service.CreateSateliteAsync(request);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Sputnik", resultado.SateliteNome);
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Satelite>()), Times.Once);
        }
    }
}
