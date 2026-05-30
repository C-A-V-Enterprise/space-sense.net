using SpaceSense.Api.DTOs;

namespace SpaceSense.Api.Services
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaResponseDTO>> GetEmpresasAsync();
        Task<EmpresaResponseDTO> CreateEmpresaAsync(EmpresaRequestDTO request);
        Task<EmpresaResponseDTO?> GetEmpresaByIdAsync(int id);
        Task<EmpresaResponseDTO?> UpdateEmpresaAsync(int id, EmpresaRequestDTO request);
        Task<bool> DeleteEmpresaAsync(int id);
    }
}
