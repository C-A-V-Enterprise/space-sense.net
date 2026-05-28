using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
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
        public async Task<ActionResult<IEnumerable<Plataforma>>> GetPlataformas()
        {
            return await _context.Plataformas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Plataforma>> PostPlataforma(Plataforma plataforma)
        {
            _context.Plataformas.Add(plataforma);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlataformas), new { id = plataforma.PlataformaId }, plataforma);
        }
    }
}
