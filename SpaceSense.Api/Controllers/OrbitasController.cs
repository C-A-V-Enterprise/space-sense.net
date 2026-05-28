using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
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
        public async Task<ActionResult<IEnumerable<Orbita>>> GetOrbitas()
        {
            return await _context.Orbitas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Orbita>> PostOrbita(Orbita orbita)
        {
            _context.Orbitas.Add(orbita);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrbitas), new { id = orbita.OrbitaId }, orbita);
        }
    }
}
