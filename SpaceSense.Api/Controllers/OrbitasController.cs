using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrbitasController : ControllerBase
    {
        private readonly SatGuardDbContext _context;

        public OrbitasController(SatGuardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrbitaResponseDTO>>> GetOrbitas()
        {
            var orbitas = await _context.Orbitas.ToListAsync();
            var response = orbitas.Select(o => new OrbitaResponseDTO
            {
                OrbitaId = o.OrbitaId,
                OrbitaAltitudeKm = o.OrbitaAltitudeKm,
                OrbitaCategoria = o.OrbitaCategoria,
                OrbitaInclinacao = o.OrbitaInclinacao
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<OrbitaResponseDTO>> PostOrbita(OrbitaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orbita = new Orbita
            {
                OrbitaAltitudeKm = request.OrbitaAltitudeKm,
                OrbitaCategoria = request.OrbitaCategoria,
                OrbitaInclinacao = request.OrbitaInclinacao
            };

            _context.Orbitas.Add(orbita);
            await _context.SaveChangesAsync();

            var response = new OrbitaResponseDTO
            {
                OrbitaId = orbita.OrbitaId,
                OrbitaAltitudeKm = orbita.OrbitaAltitudeKm,
                OrbitaCategoria = orbita.OrbitaCategoria,
                OrbitaInclinacao = orbita.OrbitaInclinacao
            };

            return CreatedAtAction(nameof(GetOrbitas), new { id = response.OrbitaId }, response);
        }
    }
}
