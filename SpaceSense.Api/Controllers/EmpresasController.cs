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
            return CreatedAtAction(nameof(GetEmpresas), new { id = response.EmpresaId }, response);
        }
    }
}
