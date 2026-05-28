using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface IAlertaService
    {
        Task<IEnumerable<AlertaResponseDTO>> GetAlertasAsync();
        Task<AlertaResponseDTO> CreateAlertaAsync(AlertaRequestDTO request);
    }
}
