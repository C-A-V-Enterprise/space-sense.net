using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;
using SpaceSense.Api.Repositories;

namespace SpaceSense.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _repository;

        public UsuarioService(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> GetUsuariosAsync()
        {
            var usuarios = await _repository.GetAllAsync();
            return usuarios.Select(u => new UsuarioResponseDTO
            {
                UsuarioId = u.UsuarioId,
                UsuarioNome = u.UsuarioNome,
                UsuarioEmail = u.UsuarioEmail,
                UsuarioTipo = u.UsuarioTipo,
                PlataformaId = u.PlataformaId
            });
        }

        public async Task<UsuarioResponseDTO> CreateUsuarioAsync(UsuarioRequestDTO request)
        {
            var usuario = new Usuario
            {
                UsuarioNome = request.UsuarioNome,
                UsuarioEmail = request.UsuarioEmail,
                UsuarioSenha = request.UsuarioSenha,
                UsuarioTipo = request.UsuarioTipo,
                PlataformaId = request.PlataformaId
            };

            await _repository.AddAsync(usuario);

            return new UsuarioResponseDTO
            {
                UsuarioId = usuario.UsuarioId,
                UsuarioNome = usuario.UsuarioNome,
                UsuarioEmail = usuario.UsuarioEmail,
                UsuarioTipo = usuario.UsuarioTipo,
                PlataformaId = usuario.PlataformaId
            };
        }
    }
}
