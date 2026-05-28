using Microsoft.AspNetCore.Mvc;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Services;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetUsuarios()
        {
            var response = await _service.GetUsuariosAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDTO>> PostUsuario(UsuarioRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateUsuarioAsync(request);
            return CreatedAtAction(nameof(GetUsuarios), new { id = response.UsuarioId }, response);
        }
    }
}
