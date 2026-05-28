using System.ComponentModel.DataAnnotations;

namespace SpaceSense.Api.DTOs
{
    public class SateliteRequestDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string SateliteNome { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string SateliteFuncao { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string SateliteStatus { get; set; } = string.Empty;

        [Required]
        public DateTime SateliteDataLancamento { get; set; }

        [Required]
        public decimal SateliteVelocidade { get; set; }

        [Required]
        public int EmpresaId { get; set; }

        [Required]
        public int OrbitaId { get; set; }
    }

    public class SateliteResponseDTO
    {
        public int SateliteId { get; set; }
        public string SateliteNome { get; set; } = string.Empty;
        public string SateliteFuncao { get; set; } = string.Empty;
        public string SateliteStatus { get; set; } = string.Empty;
        public DateTime SateliteDataLancamento { get; set; }
        public decimal SateliteVelocidade { get; set; }
        
        public int EmpresaId { get; set; }
        public int OrbitaId { get; set; }
    }
}
