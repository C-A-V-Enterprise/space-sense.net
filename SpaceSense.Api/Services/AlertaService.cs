using SpaceSense.Api.DTOs;
using SpaceSense.Api.Models;
using SpaceSense.Api.Repositories;

namespace SpaceSense.Api.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly IRepository<Alerta> _repository;

        public AlertaService(IRepository<Alerta> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AlertaResponseDTO>> GetAlertasAsync()
        {
            var alertas = await _repository.GetAllAsync();
            return alertas.Select(a => new AlertaResponseDTO
            {
                AlertaId = a.AlertaId,
                AlertaNivel = a.AlertaNivel,
                AlertaDescricao = a.AlertaDescricao,
                AlertaData = a.AlertaData,
                SateliteId = a.SateliteId,
                PlataformaId = a.PlataformaId
            });
        }

        public async Task<AlertaResponseDTO> CreateAlertaAsync(AlertaRequestDTO request)
        {
            var alerta = new Alerta
            {
                AlertaNivel = request.AlertaNivel,
                AlertaDescricao = request.AlertaDescricao,
                AlertaData = request.AlertaData,
                SateliteId = request.SateliteId,
                PlataformaId = request.PlataformaId
            };

            await _repository.AddAsync(alerta);

            return new AlertaResponseDTO
            {
                AlertaId = alerta.AlertaId,
                AlertaNivel = alerta.AlertaNivel,
                AlertaDescricao = alerta.AlertaDescricao,
                AlertaData = alerta.AlertaData,
                SateliteId = alerta.SateliteId,
                PlataformaId = alerta.PlataformaId
            };
        }
    }
}
