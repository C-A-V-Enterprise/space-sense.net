using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponseDTO>> GetUsuariosAsync();
        Task<UsuarioResponseDTO> CreateUsuarioAsync(UsuarioRequestDTO request);
    }
}
