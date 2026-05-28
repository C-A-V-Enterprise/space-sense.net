using Microsoft.AspNetCore.Mvc;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Services;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrbitasController : ControllerBase
    {
        private readonly IOrbitaService _service;

        public OrbitasController(IOrbitaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrbitaResponseDTO>>> GetOrbitas()
        {
            var response = await _service.GetOrbitasAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<OrbitaResponseDTO>> PostOrbita(OrbitaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateOrbitaAsync(request);
            return CreatedAtAction(nameof(GetOrbitas), new { id = response.OrbitaId }, response);
        }
    }
}
