using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface ISateliteService
    {
        Task<IEnumerable<SateliteResponseDTO>> GetSatelitesAsync();
        Task<SateliteResponseDTO> CreateSateliteAsync(SateliteRequestDTO request);
        Task<SateliteResponseDTO?> GetSateliteByIdAsync(int id);
        Task<SateliteResponseDTO?> UpdateSateliteAsync(int id, SateliteRequestDTO request);
        Task<bool> DeleteSateliteAsync(int id);
    }
}
