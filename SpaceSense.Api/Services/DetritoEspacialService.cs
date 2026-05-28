using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;
using SpaceSense.Api.Repositories;

namespace SpaceSense.Api.Services
{
    public class DetritoEspacialService : IDetritoEspacialService
    {
        private readonly IRepository<DetritoEspacial> _repository;

        public DetritoEspacialService(IRepository<DetritoEspacial> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DetritoEspacialResponseDTO>> GetDetritosEspaciaisAsync()
        {
            var detritos = await _repository.GetAllAsync();
            return detritos.Select(d => new DetritoEspacialResponseDTO
            {
                DetritoId = d.DetritoId,
                DetritoTamanho = d.DetritoTamanho,
                DetritoRiscoColisao = d.DetritoRiscoColisao,
                DetritoVelocidade = d.DetritoVelocidade,
                OrbitaId = d.OrbitaId
            });
        }

        public async Task<DetritoEspacialResponseDTO> CreateDetritoEspacialAsync(DetritoEspacialRequestDTO request)
        {
            var detrito = new DetritoEspacial
            {
                DetritoTamanho = request.DetritoTamanho,
                DetritoRiscoColisao = request.DetritoRiscoColisao,
                DetritoVelocidade = request.DetritoVelocidade,
                OrbitaId = request.OrbitaId
            };

            await _repository.AddAsync(detrito);

            return new DetritoEspacialResponseDTO
            {
                DetritoId = detrito.DetritoId,
                DetritoTamanho = detrito.DetritoTamanho,
                DetritoRiscoColisao = detrito.DetritoRiscoColisao,
                DetritoVelocidade = detrito.DetritoVelocidade,
                OrbitaId = detrito.OrbitaId
            };
        }
    }
}
