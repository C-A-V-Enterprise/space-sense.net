using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface ISateliteService
    {
        Task<IEnumerable<SateliteResponseDTO>> GetSatelitesAsync();
        Task<SateliteResponseDTO> CreateSateliteAsync(SateliteRequestDTO request);
    }
}
