using System.ComponentModel.DataAnnotations;

namespace SpaceSense.Api.DTOs
{
    public class AlertaRequestDTO
    {
        [Required]
        [StringLength(20)]
        public string AlertaNivel { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string AlertaDescricao { get; set; } = string.Empty;

        [Required]
        public DateTime AlertaData { get; set; }

        [Required]
        public int SateliteId { get; set; }

        [Required]
        public int PlataformaId { get; set; }
    }

    public class AlertaResponseDTO
    {
        public int AlertaId { get; set; }
        public string AlertaNivel { get; set; } = string.Empty;
        public string AlertaDescricao { get; set; } = string.Empty;
        public DateTime AlertaData { get; set; }
        public int SateliteId { get; set; }
        public int PlataformaId { get; set; }
    }
}
