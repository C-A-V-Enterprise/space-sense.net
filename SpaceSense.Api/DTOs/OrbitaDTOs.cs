using System.ComponentModel.DataAnnotations;

namespace SpaceSense.Api.DTOs
{
    public class OrbitaRequestDTO
    {
        [Required(ErrorMessage = "A altitude é obrigatória")]
        [Range(0, 100000, ErrorMessage = "Altitude inválida")]
        public decimal OrbitaAltitudeKm { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(50)]
        public string OrbitaCategoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "A inclinação é obrigatória")]
        [Range(-180, 180, ErrorMessage = "Inclinação inválida")]
        public decimal OrbitaInclinacao { get; set; }
    }

    public class OrbitaResponseDTO
    {
        public int OrbitaId { get; set; }
        public decimal OrbitaAltitudeKm { get; set; }
        public string OrbitaCategoria { get; set; } = string.Empty;
        public decimal OrbitaInclinacao { get; set; }
    }
}
