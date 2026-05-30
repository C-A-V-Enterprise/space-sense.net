using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Services;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatelitesController : ControllerBase
    {
        private readonly ISateliteService _service;

        public SatelitesController(ISateliteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SateliteResponseDTO>>> GetSatelites()
        {
            var response = await _service.GetSatelitesAsync();
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SateliteResponseDTO>> PostSatelite(SateliteRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateSateliteAsync(request);
            return CreatedAtAction(nameof(GetSatelite), new { id = response.SateliteId }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SateliteResponseDTO>> GetSatelite(int id)
        {
            var response = await _service.GetSateliteByIdAsync(id);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<SateliteResponseDTO>> PutSatelite(int id, SateliteRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.UpdateSateliteAsync(id, request);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatelite(int id)
        {
            var deleted = await _service.DeleteSateliteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
