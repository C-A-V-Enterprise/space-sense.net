using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    [Table("DETRITO_ESPACIAL")]
    public class DetritoEspacial
    {
        [Key]
        [Column("detrito_id")]
        public int DetritoId { get; set; }

        [Column("detrito_tamanho", TypeName = "decimal(4, 1)")]
        public decimal DetritoTamanho { get; set; }

        [Column("detrito_risco_colisao", TypeName = "decimal(5, 2)")]
        public decimal DetritoRiscoColisao { get; set; }

        [Column("detrito_velocidade", TypeName = "decimal(10, 2)")]
        public decimal DetritoVelocidade { get; set; }

        [Column("orbita_id")]
        public int OrbitaId { get; set; }
        public Orbita? Orbita { get; set; }
    }
}
