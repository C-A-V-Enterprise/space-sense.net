using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.Models;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatelitesController : ControllerBase
    {
        private readonly SatGuardDbContext _context;

        public SatelitesController(SatGuardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Satelite>>> GetSatelites()
        {
            return await _context.Satelites.Include(s => s.Empresa).Include(s => s.Orbita).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Satelite>> GetSatelite(int id)
        {
            var satelite = await _context.Satelites.Include(s => s.Empresa).Include(s => s.Orbita).FirstOrDefaultAsync(s => s.SateliteId == id);

            if (satelite == null)
            {
                return NotFound();
            }

            return satelite;
        }

        [HttpPost]
        public async Task<ActionResult<Satelite>> PostSatelite(Satelite satelite)
        {
            _context.Satelites.Add(satelite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSatelite), new { id = satelite.SateliteId }, satelite);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatelite(int id, Satelite satelite)
        {
            if (id != satelite.SateliteId)
            {
                return BadRequest();
            }

            _context.Entry(satelite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SateliteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatelite(int id)
        {
            var satelite = await _context.Satelites.FindAsync(id);
            if (satelite == null)
            {
                return NotFound();
            }

            _context.Satelites.Remove(satelite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SateliteExists(int id)
        {
            return _context.Satelites.Any(e => e.SateliteId == id);
        }
    }
}
