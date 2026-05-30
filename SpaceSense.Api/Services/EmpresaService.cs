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
                EmpresaPais = e.EmpresaPais,
                EnderecoRua = e.EnderecoSede?.Rua,
                EnderecoCidade = e.EnderecoSede?.Cidade,
                EnderecoEstado = e.EnderecoSede?.Estado,
                EnderecoCep = e.EnderecoSede?.Cep
            });
        }

        public async Task<EmpresaResponseDTO> CreateEmpresaAsync(EmpresaRequestDTO request)
        {
            var empresa = new Empresa
            {
                EmpresaNome = request.EmpresaNome,
                EmpresaPais = request.EmpresaPais,
                EnderecoSede = new Endereco
                {
                    Rua = request.EnderecoRua ?? string.Empty,
                    Cidade = request.EnderecoCidade ?? string.Empty,
                    Estado = request.EnderecoEstado ?? string.Empty,
                    Cep = request.EnderecoCep ?? string.Empty
                }
            };

            await _repository.AddAsync(empresa);

            return new EmpresaResponseDTO
            {
                EmpresaId = empresa.EmpresaId,
                EmpresaNome = empresa.EmpresaNome,
                EmpresaPais = empresa.EmpresaPais,
                EnderecoRua = empresa.EnderecoSede?.Rua,
                EnderecoCidade = empresa.EnderecoSede?.Cidade,
                EnderecoEstado = empresa.EnderecoSede?.Estado,
                EnderecoCep = empresa.EnderecoSede?.Cep
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
                EmpresaPais = e.EmpresaPais,
                EnderecoRua = e.EnderecoSede?.Rua,
                EnderecoCidade = e.EnderecoSede?.Cidade,
                EnderecoEstado = e.EnderecoSede?.Estado,
                EnderecoCep = e.EnderecoSede?.Cep
            };
        }

        public async Task<EmpresaResponseDTO?> UpdateEmpresaAsync(int id, EmpresaRequestDTO request)
        {
            var empresa = await _repository.GetByIdAsync(id);
            if (empresa == null) return null;

            empresa.EmpresaNome = request.EmpresaNome;
            empresa.EmpresaPais = request.EmpresaPais;

            if (empresa.EnderecoSede == null)
            {
                empresa.EnderecoSede = new Endereco();
            }
            empresa.EnderecoSede.Rua = request.EnderecoRua ?? string.Empty;
            empresa.EnderecoSede.Cidade = request.EnderecoCidade ?? string.Empty;
            empresa.EnderecoSede.Estado = request.EnderecoEstado ?? string.Empty;
            empresa.EnderecoSede.Cep = request.EnderecoCep ?? string.Empty;

            await _repository.UpdateAsync(empresa);

            return new EmpresaResponseDTO
            {
                EmpresaId = empresa.EmpresaId,
                EmpresaNome = empresa.EmpresaNome,
                EmpresaPais = empresa.EmpresaPais,
                EnderecoRua = empresa.EnderecoSede?.Rua,
                EnderecoCidade = empresa.EnderecoSede?.Cidade,
                EnderecoEstado = empresa.EnderecoSede?.Estado,
                EnderecoCep = empresa.EnderecoSede?.Cep
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
