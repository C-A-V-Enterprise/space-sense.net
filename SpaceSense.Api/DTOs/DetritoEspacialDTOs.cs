using System.ComponentModel.DataAnnotations;

namespace SpaceSense.Api.DTOs
{
    public class DetritoEspacialRequestDTO
    {
        [Required]
        [Range(0, 1000)]
        public decimal DetritoTamanho { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal DetritoRiscoColisao { get; set; }

        [Required]
        public decimal DetritoVelocidade { get; set; }

        [Required]
        public int OrbitaId { get; set; }
    }

    public class DetritoEspacialResponseDTO
    {
        public int DetritoId { get; set; }
        public decimal DetritoTamanho { get; set; }
        public decimal DetritoRiscoColisao { get; set; }
        public decimal DetritoVelocidade { get; set; }
        public int OrbitaId { get; set; }
    }
}
