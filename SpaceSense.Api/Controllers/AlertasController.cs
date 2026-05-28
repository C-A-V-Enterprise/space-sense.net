using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.DTOs;
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
        public async Task<ActionResult<IEnumerable<AlertaResponseDTO>>> GetAlertas()
        {
            var alertas = await _context.Alertas.ToListAsync();
            var response = alertas.Select(a => new AlertaResponseDTO
            {
                AlertaId = a.AlertaId,
                AlertaNivel = a.AlertaNivel,
                AlertaDescricao = a.AlertaDescricao,
                AlertaData = a.AlertaData,
                SateliteId = a.SateliteId,
                PlataformaId = a.PlataformaId
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AlertaResponseDTO>> PostAlerta(AlertaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alerta = new Alerta
            {
                AlertaNivel = request.AlertaNivel,
                AlertaDescricao = request.AlertaDescricao,
                AlertaData = request.AlertaData,
                SateliteId = request.SateliteId,
                PlataformaId = request.PlataformaId
            };

            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();

            var response = new AlertaResponseDTO
            {
                AlertaId = alerta.AlertaId,
                AlertaNivel = alerta.AlertaNivel,
                AlertaDescricao = alerta.AlertaDescricao,
                AlertaData = alerta.AlertaData,
                SateliteId = alerta.SateliteId,
                PlataformaId = alerta.PlataformaId
            };

            return CreatedAtAction(nameof(GetAlertas), new { id = response.AlertaId }, response);
        }
    }
}
