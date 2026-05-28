using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly SatGuardDbContext _context;

        public UsuariosController(SatGuardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            var response = usuarios.Select(u => new UsuarioResponseDTO
            {
                UsuarioId = u.UsuarioId,
                UsuarioNome = u.UsuarioNome,
                UsuarioEmail = u.UsuarioEmail,
                UsuarioTipo = u.UsuarioTipo,
                PlataformaId = u.PlataformaId
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDTO>> PostUsuario(UsuarioRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                UsuarioNome = request.UsuarioNome,
                UsuarioEmail = request.UsuarioEmail,
                UsuarioSenha = request.UsuarioSenha, // Em produção, a senha deve ser hasheada!
                UsuarioTipo = request.UsuarioTipo,
                PlataformaId = request.PlataformaId
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var response = new UsuarioResponseDTO
            {
                UsuarioId = usuario.UsuarioId,
                UsuarioNome = usuario.UsuarioNome,
                UsuarioEmail = usuario.UsuarioEmail,
                UsuarioTipo = usuario.UsuarioTipo,
                PlataformaId = usuario.PlataformaId
            };

            return CreatedAtAction(nameof(GetUsuarios), new { id = response.UsuarioId }, response);
        }
    }
}
