using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.Models;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertasController : ControllerBase
    {
        private readonly SatGuardDbContext _context;

        public AlertasController(SatGuardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAlertas()
        {
            return await _context.Alertas.Include(a => a.Satelite).Include(a => a.Plataforma).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> GetAlerta(int id)
        {
            var alerta = await _context.Alertas.Include(a => a.Satelite).Include(a => a.Plataforma).FirstOrDefaultAsync(a => a.AlertaId == id);

            if (alerta == null)
            {
                return NotFound();
            }

            return alerta;
        }

        [HttpPost]
        public async Task<ActionResult<Alerta>> PostAlerta(Alerta alerta)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlerta), new { id = alerta.AlertaId }, alerta);
        }
    }
}
