using Microsoft.AspNetCore.Mvc;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Services;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        private readonly IPlataformaService _service;

        public PlataformasController(IPlataformaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlataformaResponseDTO>>> GetPlataformas()
        {
            var response = await _service.GetPlataformasAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PlataformaResponseDTO>> PostPlataforma(PlataformaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreatePlataformaAsync(request);
            return CreatedAtAction(nameof(GetPlataformas), new { id = response.PlataformaId }, response);
        }
    }
}
