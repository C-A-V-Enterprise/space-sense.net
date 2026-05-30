using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;
using SpaceSense.Api.Repositories;

namespace SpaceSense.Api.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IRepository<Empresa> _repository;

        public EmpresaService(IRepository<Empresa> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmpresaResponseDTO>> GetEmpresasAsync()
        {
            var empresas = await _repository.GetAllAsync();
            return empresas.Select(e => new EmpresaResponseDTO
            {
                EmpresaId = e.EmpresaId,
                EmpresaNome = e.EmpresaNome,
                EmpresaPais = e.EmpresaPais
            });
        }

        public async Task<EmpresaResponseDTO> CreateEmpresaAsync(EmpresaRequestDTO request)
        {
            var empresa = new Empresa
            {
                EmpresaNome = request.EmpresaNome,
                EmpresaPais = request.EmpresaPais
            };

            await _repository.AddAsync(empresa);

            return new EmpresaResponseDTO
            {
                EmpresaId = empresa.EmpresaId,
                EmpresaNome = empresa.EmpresaNome,
                EmpresaPais = empresa.EmpresaPais
            };
        }

        public async Task<EmpresaResponseDTO?> GetEmpresaByIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return null;

            return new EmpresaResponseDTO
            {
                EmpresaId = e.EmpresaId,
                EmpresaNome = e.EmpresaNome,
                EmpresaPais = e.EmpresaPais
            };
        }

        public async Task<EmpresaResponseDTO?> UpdateEmpresaAsync(int id, EmpresaRequestDTO request)
        {
            var empresa = await _repository.GetByIdAsync(id);
            if (empresa == null) return null;

            empresa.EmpresaNome = request.EmpresaNome;
            empresa.EmpresaPais = request.EmpresaPais;

            await _repository.UpdateAsync(empresa);

            return new EmpresaResponseDTO
            {
                EmpresaId = empresa.EmpresaId,
                EmpresaNome = empresa.EmpresaNome,
                EmpresaPais = empresa.EmpresaPais
            };
        }

        public async Task<bool> DeleteEmpresaAsync(int id)
        {
            var empresa = await _repository.GetByIdAsync(id);
            if (empresa == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
