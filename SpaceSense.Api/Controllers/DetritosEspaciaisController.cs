using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetritosEspaciaisController : ControllerBase
    {
        private readonly SatGuardDbContext _context;

        public DetritosEspaciaisController(SatGuardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetritoEspacialResponseDTO>>> GetDetritosEspaciais()
        {
            var detritos = await _context.DetritosEspaciais.ToListAsync();
            var response = detritos.Select(d => new DetritoEspacialResponseDTO
            {
                DetritoId = d.DetritoId,
                DetritoTamanho = d.DetritoTamanho,
                DetritoRiscoColisao = d.DetritoRiscoColisao,
                DetritoVelocidade = d.DetritoVelocidade,
                OrbitaId = d.OrbitaId
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<DetritoEspacialResponseDTO>> PostDetritoEspacial(DetritoEspacialRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detrito = new DetritoEspacial
            {
                DetritoTamanho = request.DetritoTamanho,
                DetritoRiscoColisao = request.DetritoRiscoColisao,
                DetritoVelocidade = request.DetritoVelocidade,
                OrbitaId = request.OrbitaId
            };

            _context.DetritosEspaciais.Add(detrito);
            await _context.SaveChangesAsync();

            var response = new DetritoEspacialResponseDTO
            {
                DetritoId = detrito.DetritoId,
                DetritoTamanho = detrito.DetritoTamanho,
                DetritoRiscoColisao = detrito.DetritoRiscoColisao,
                DetritoVelocidade = detrito.DetritoVelocidade,
                OrbitaId = detrito.OrbitaId
            };

            return CreatedAtAction(nameof(GetDetritosEspaciais), new { id = response.DetritoId }, response);
        }
    }
}
