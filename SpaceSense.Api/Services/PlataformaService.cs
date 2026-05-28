using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;
using SpaceSense.Api.Repositories;

namespace SpaceSense.Api.Services
{
    public class PlataformaService : IPlataformaService
    {
        private readonly IRepository<Plataforma> _repository;

        public PlataformaService(IRepository<Plataforma> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlataformaResponseDTO>> GetPlataformasAsync()
        {
            var plataformas = await _repository.GetAllAsync();
            return plataformas.Select(p => new PlataformaResponseDTO
            {
                PlataformaId = p.PlataformaId,
                PlataformaNome = p.PlataformaNome,
                PlataformaStatus = p.PlataformaStatus
            });
        }

        public async Task<PlataformaResponseDTO> CreatePlataformaAsync(PlataformaRequestDTO request)
        {
            var plataforma = new Plataforma
            {
                PlataformaNome = request.PlataformaNome,
                PlataformaStatus = request.PlataformaStatus
            };

            await _repository.AddAsync(plataforma);

            return new PlataformaResponseDTO
            {
                PlataformaId = plataforma.PlataformaId,
                PlataformaNome = plataforma.PlataformaNome,
                PlataformaStatus = plataforma.PlataformaStatus
            };
        }
    }
}
