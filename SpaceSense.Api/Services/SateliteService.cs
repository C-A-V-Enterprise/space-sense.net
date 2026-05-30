using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;
using SpaceSense.Api.Repositories;

namespace SpaceSense.Api.Services
{
    public class SateliteService : ISateliteService
    {
        private readonly IRepository<Satelite> _repository;

        public SateliteService(IRepository<Satelite> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SateliteResponseDTO>> GetSatelitesAsync()
        {
            var satelites = await _repository.GetAllAsync();
            return satelites.Select(s => new SateliteResponseDTO
            {
                SateliteId = s.SateliteId,
                SateliteNome = s.SateliteNome,
                SateliteFuncao = s.SateliteFuncao,
                SateliteStatus = s.SateliteStatus,
                SateliteDataLancamento = s.SateliteDataLancamento,
                SateliteVelocidade = s.SateliteVelocidade,
                EmpresaId = s.EmpresaId,
                OrbitaId = s.OrbitaId
            });
        }

        public async Task<SateliteResponseDTO> CreateSateliteAsync(SateliteRequestDTO request)
        {
            var satelite = new Satelite
            {
                SateliteNome = request.SateliteNome,
                SateliteFuncao = request.SateliteFuncao,
                SateliteStatus = request.SateliteStatus,
                SateliteDataLancamento = request.SateliteDataLancamento,
                SateliteVelocidade = request.SateliteVelocidade,
                EmpresaId = request.EmpresaId,
                OrbitaId = request.OrbitaId
            };

            await _repository.AddAsync(satelite);

            return new SateliteResponseDTO
            {
                SateliteId = satelite.SateliteId,
                SateliteNome = satelite.SateliteNome,
                SateliteFuncao = satelite.SateliteFuncao,
                SateliteStatus = satelite.SateliteStatus,
                SateliteDataLancamento = satelite.SateliteDataLancamento,
                SateliteVelocidade = satelite.SateliteVelocidade,
                EmpresaId = satelite.EmpresaId,
                OrbitaId = satelite.OrbitaId
            };
        }

        public async Task<SateliteResponseDTO?> GetSateliteByIdAsync(int id)
        {
            var s = await _repository.GetByIdAsync(id);
            if (s == null) return null;

            return new SateliteResponseDTO
            {
                SateliteId = s.SateliteId,
                SateliteNome = s.SateliteNome,
                SateliteFuncao = s.SateliteFuncao,
                SateliteStatus = s.SateliteStatus,
                SateliteDataLancamento = s.SateliteDataLancamento,
                SateliteVelocidade = s.SateliteVelocidade,
                EmpresaId = s.EmpresaId,
                OrbitaId = s.OrbitaId
            };
        }

        public async Task<SateliteResponseDTO?> UpdateSateliteAsync(int id, SateliteRequestDTO request)
        {
            var satelite = await _repository.GetByIdAsync(id);
            if (satelite == null) return null;

            satelite.SateliteNome = request.SateliteNome;
            satelite.SateliteFuncao = request.SateliteFuncao;
            satelite.SateliteStatus = request.SateliteStatus;
            satelite.SateliteDataLancamento = request.SateliteDataLancamento;
            satelite.SateliteVelocidade = request.SateliteVelocidade;
            satelite.EmpresaId = request.EmpresaId;
            satelite.OrbitaId = request.OrbitaId;

            await _repository.UpdateAsync(satelite);

            return new SateliteResponseDTO
            {
                SateliteId = satelite.SateliteId,
                SateliteNome = satelite.SateliteNome,
                SateliteFuncao = satelite.SateliteFuncao,
                SateliteStatus = satelite.SateliteStatus,
                SateliteDataLancamento = satelite.SateliteDataLancamento,
                SateliteVelocidade = satelite.SateliteVelocidade,
                EmpresaId = satelite.EmpresaId,
                OrbitaId = satelite.OrbitaId
            };
        }

        public async Task<bool> DeleteSateliteAsync(int id)
        {
            var satelite = await _repository.GetByIdAsync(id);
            if (satelite == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
