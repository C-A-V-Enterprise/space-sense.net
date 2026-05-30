using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    public abstract class ObjetoEspacial
    {
        [Key]
        [Column("objeto_id")]
        public int Id { get; set; }

        [Column("velocidade", TypeName = "decimal(10, 2)")]
        public decimal Velocidade { get; set; }

        [Column("orbita_id")]
        public int OrbitaId { get; set; }
        public Orbita? Orbita { get; set; }
    }
}
