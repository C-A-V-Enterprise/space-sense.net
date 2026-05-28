using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    [Table("PLATAFORMA")]
    public class Plataforma
    {
        [Key]
        [Column("plataforma_id")]
        public int PlataformaId { get; set; }

        [Column("plataforma_nome")]
        [StringLength(50)]
        public string PlataformaNome { get; set; } = string.Empty;

        [Column("plataforma_status")]
        [StringLength(1)]
        public string PlataformaStatus { get; set; } = string.Empty;
    }
}
