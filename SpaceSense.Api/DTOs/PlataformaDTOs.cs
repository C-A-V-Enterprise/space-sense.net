using System.ComponentModel.DataAnnotations;

namespace SpaceSense.Api.DTOs
{
    public class PlataformaRequestDTO
    {
        [Required]
        [StringLength(100)]
        public string PlataformaNome { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string PlataformaStatus { get; set; } = string.Empty;
    }

    public class PlataformaResponseDTO
    {
        public int PlataformaId { get; set; }
        public string PlataformaNome { get; set; } = string.Empty;
        public string PlataformaStatus { get; set; } = string.Empty;
    }
}
