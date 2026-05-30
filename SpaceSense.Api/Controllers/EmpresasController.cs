using Microsoft.AspNetCore.Mvc;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Services;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _service;

        public EmpresasController(IEmpresaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaResponseDTO>>> GetEmpresas()
        {
            var response = await _service.GetEmpresasAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaResponseDTO>> PostEmpresa(EmpresaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateEmpresaAsync(request);
            return CreatedAtAction(nameof(GetEmpresa), new { id = response.EmpresaId }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaResponseDTO>> GetEmpresa(int id)
        {
            var response = await _service.GetEmpresaByIdAsync(id);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpresaResponseDTO>> PutEmpresa(int id, EmpresaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.UpdateEmpresaAsync(id, request);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var deleted = await _service.DeleteEmpresaAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
