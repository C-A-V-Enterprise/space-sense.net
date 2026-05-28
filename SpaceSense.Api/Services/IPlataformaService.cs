using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface IPlataformaService
    {
        Task<IEnumerable<PlataformaResponseDTO>> GetPlataformasAsync();
        Task<PlataformaResponseDTO> CreatePlataformaAsync(PlataformaRequestDTO request);
    }
}
