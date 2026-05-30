using System.ComponentModel.DataAnnotations;

namespace SpaceSense.Api.DTOs
{
    public class EmpresaRequestDTO
    {
        [Required(ErrorMessage = "O nome da empresa é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string EmpresaNome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O país da empresa é obrigatório")]
        [StringLength(50, ErrorMessage = "O país deve ter no máximo 50 caracteres")]
        public string EmpresaPais { get; set; } = string.Empty;

        public string? EnderecoRua { get; set; }
        public string? EnderecoCidade { get; set; }
        public string? EnderecoEstado { get; set; }
        public string? EnderecoCep { get; set; }
    }

    public class EmpresaResponseDTO
    {
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; } = string.Empty;
        public string EmpresaPais { get; set; } = string.Empty;
        public string? EnderecoRua { get; set; }
        public string? EnderecoCidade { get; set; }
        public string? EnderecoEstado { get; set; }
        public string? EnderecoCep { get; set; }
    }
}
