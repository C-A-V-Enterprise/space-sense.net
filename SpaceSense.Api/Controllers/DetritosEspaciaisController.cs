using Microsoft.AspNetCore.Mvc;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Services;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetritosEspaciaisController : ControllerBase
    {
        private readonly IDetritoEspacialService _service;

        public DetritosEspaciaisController(IDetritoEspacialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetritoEspacialResponseDTO>>> GetDetritosEspaciais()
        {
            var response = await _service.GetDetritosEspaciaisAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<DetritoEspacialResponseDTO>> PostDetritoEspacial(DetritoEspacialRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateDetritoEspacialAsync(request);
            return CreatedAtAction(nameof(GetDetritosEspaciais), new { id = response.DetritoId }, response);
        }
    }
}
