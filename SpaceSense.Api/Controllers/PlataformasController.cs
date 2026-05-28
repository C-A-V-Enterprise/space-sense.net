using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        private readonly SatGuardDbContext _context;

        public PlataformasController(SatGuardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlataformaResponseDTO>>> GetPlataformas()
        {
            var plataformas = await _context.Plataformas.ToListAsync();
            var response = plataformas.Select(p => new PlataformaResponseDTO
            {
                PlataformaId = p.PlataformaId,
                PlataformaNome = p.PlataformaNome,
                PlataformaStatus = p.PlataformaStatus
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PlataformaResponseDTO>> PostPlataforma(PlataformaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plataforma = new Plataforma
            {
                PlataformaNome = request.PlataformaNome,
                PlataformaStatus = request.PlataformaStatus
            };

            _context.Plataformas.Add(plataforma);
            await _context.SaveChangesAsync();

            var response = new PlataformaResponseDTO
            {
                PlataformaId = plataforma.PlataformaId,
                PlataformaNome = plataforma.PlataformaNome,
                PlataformaStatus = plataforma.PlataformaStatus
            };

            return CreatedAtAction(nameof(GetPlataformas), new { id = response.PlataformaId }, response);
        }
    }
}
