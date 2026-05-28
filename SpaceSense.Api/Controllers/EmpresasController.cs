using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly SatGuardDbContext _context;

        public EmpresasController(SatGuardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaResponseDTO>>> GetEmpresas()
        {
            var empresas = await _context.Empresas.ToListAsync();
            var response = empresas.Select(e => new EmpresaResponseDTO
            {
                EmpresaId = e.EmpresaId,
                EmpresaNome = e.EmpresaNome,
                EmpresaPais = e.EmpresaPais
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaResponseDTO>> PostEmpresa(EmpresaRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa = new Empresa
            {
                EmpresaNome = request.EmpresaNome,
                EmpresaPais = request.EmpresaPais
            };

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            var response = new EmpresaResponseDTO
            {
                EmpresaId = empresa.EmpresaId,
                EmpresaNome = empresa.EmpresaNome,
                EmpresaPais = empresa.EmpresaPais
            };

            return CreatedAtAction(nameof(GetEmpresas), new { id = response.EmpresaId }, response);
        }
    }
}
