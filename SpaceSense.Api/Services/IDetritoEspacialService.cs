using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface IDetritoEspacialService
    {
        Task<IEnumerable<DetritoEspacialResponseDTO>> GetDetritosEspaciaisAsync();
        Task<DetritoEspacialResponseDTO> CreateDetritoEspacialAsync(DetritoEspacialRequestDTO request);
    }
}
