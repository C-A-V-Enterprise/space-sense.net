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
    }
}
