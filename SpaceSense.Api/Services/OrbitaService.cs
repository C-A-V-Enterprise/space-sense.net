using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;
using SpaceSense.Api.Repositories;

namespace SpaceSense.Api.Services
{
    public class OrbitaService : IOrbitaService
    {
        private readonly IRepository<Orbita> _repository;

        public OrbitaService(IRepository<Orbita> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrbitaResponseDTO>> GetOrbitasAsync()
        {
            var orbitas = await _repository.GetAllAsync();
            return orbitas.Select(o => new OrbitaResponseDTO
            {
                OrbitaId = o.OrbitaId,
                OrbitaAltitudeKm = o.OrbitaAltitudeKm,
                OrbitaCategoria = o.OrbitaCategoria,
                OrbitaInclinacao = o.OrbitaInclinacao
            });
        }

        public async Task<OrbitaResponseDTO> CreateOrbitaAsync(OrbitaRequestDTO request)
        {
            var orbita = new Orbita
            {
                OrbitaAltitudeKm = request.OrbitaAltitudeKm,
                OrbitaCategoria = request.OrbitaCategoria,
                OrbitaInclinacao = request.OrbitaInclinacao
            };

            await _repository.AddAsync(orbita);

            return new OrbitaResponseDTO
            {
                OrbitaId = orbita.OrbitaId,
                OrbitaAltitudeKm = orbita.OrbitaAltitudeKm,
                OrbitaCategoria = orbita.OrbitaCategoria,
                OrbitaInclinacao = orbita.OrbitaInclinacao
            };
        }
    }
}
