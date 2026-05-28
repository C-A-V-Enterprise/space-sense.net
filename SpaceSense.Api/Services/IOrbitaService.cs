using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface IOrbitaService
    {
        Task<IEnumerable<OrbitaResponseDTO>> GetOrbitasAsync();
        Task<OrbitaResponseDTO> CreateOrbitaAsync(OrbitaRequestDTO request);
    }
}
