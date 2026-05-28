using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaResponseDTO>> GetEmpresasAsync();
        Task<EmpresaResponseDTO> CreateEmpresaAsync(EmpresaRequestDTO request);
    }
}
