using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
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
        public async Task<ActionResult<IEnumerable<DetritoEspacial>>> GetDetritosEspaciais()
        {
            return await _context.DetritosEspaciais.Include(d => d.Orbita).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<DetritoEspacial>> PostDetritoEspacial(DetritoEspacial detrito)
        {
            _context.DetritosEspaciais.Add(detrito);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetritosEspaciais), new { id = detrito.DetritoId }, detrito);
        }
    }
}
