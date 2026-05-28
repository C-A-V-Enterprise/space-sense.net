using Microsoft.AspNetCore.Mvc;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Services;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertasController : ControllerBase
    {
        private readonly IAlertaService _service;

        public AlertasController(IAlertaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertaResponseDTO>>> GetAlertas()
        {
            var response = await _service.GetAlertasAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AlertaResponseDTO>> PostAlerta(AlertaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateAlertaAsync(request);
            return CreatedAtAction(nameof(GetAlertas), new { id = response.AlertaId }, response);
        }
    }
}
