using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    [Table("EMPRESAS")]
    public class Empresa
    {
        [Key]
        [Column("empresa_id")]
        public int EmpresaId { get; set; }

        [Column("empresa_nome")]
        [StringLength(50)]
        public string EmpresaNome { get; set; } = string.Empty;

        [Column("empresa_pais")]
        [StringLength(50)]
        public string EmpresaPais { get; set; } = string.Empty;
    }
}
