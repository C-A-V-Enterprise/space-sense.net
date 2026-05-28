using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.DTOs;
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
        public async Task<ActionResult<IEnumerable<SateliteResponseDTO>>> GetSatelites()
        {
            var satelites = await _context.Satelites.ToListAsync();
            var response = satelites.Select(s => new SateliteResponseDTO
            {
                SateliteId = s.SateliteId,
                SateliteNome = s.SateliteNome,
                SateliteFuncao = s.SateliteFuncao,
                SateliteStatus = s.SateliteStatus,
                SateliteDataLancamento = s.SateliteDataLancamento,
                SateliteVelocidade = s.SateliteVelocidade,
                EmpresaId = s.EmpresaId,
                OrbitaId = s.OrbitaId
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<SateliteResponseDTO>> PostSatelite(SateliteRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var satelite = new Satelite
            {
                SateliteNome = request.SateliteNome,
                SateliteFuncao = request.SateliteFuncao,
                SateliteStatus = request.SateliteStatus,
                SateliteDataLancamento = request.SateliteDataLancamento,
                SateliteVelocidade = request.SateliteVelocidade,
                EmpresaId = request.EmpresaId,
                OrbitaId = request.OrbitaId
            };

            _context.Satelites.Add(satelite);
            await _context.SaveChangesAsync();

            var response = new SateliteResponseDTO
            {
                SateliteId = satelite.SateliteId,
                SateliteNome = satelite.SateliteNome,
                SateliteFuncao = satelite.SateliteFuncao,
                SateliteStatus = satelite.SateliteStatus,
                SateliteDataLancamento = satelite.SateliteDataLancamento,
                SateliteVelocidade = satelite.SateliteVelocidade,
                EmpresaId = satelite.EmpresaId,
                OrbitaId = satelite.OrbitaId
            };

            return CreatedAtAction(nameof(GetSatelites), new { id = response.SateliteId }, response);
        }
    }
}
