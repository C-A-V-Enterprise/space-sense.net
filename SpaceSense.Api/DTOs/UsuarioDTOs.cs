using System.ComponentModel.DataAnnotations;

namespace SpaceSense.Api.DTOs
{
    public class UsuarioRequestDTO
    {
        [Required]
        [StringLength(100)]
        public string UsuarioNome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string UsuarioEmail { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string UsuarioSenha { get; set; } = string.Empty;

        [Required]
        public string UsuarioTipo { get; set; } = string.Empty;

        [Required]
        public int PlataformaId { get; set; }
    }

    public class UsuarioResponseDTO
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty;
        public string UsuarioEmail { get; set; } = string.Empty;
        public string UsuarioTipo { get; set; } = string.Empty;
        public int PlataformaId { get; set; }
    }
}
