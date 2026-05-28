using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    [Table("ORBITAS")]
    public class Orbita
    {
        [Key]
        [Column("orbita_id")]
        public int OrbitaId { get; set; }

        [Column("orbita_altitude_km", TypeName = "decimal(10, 2)")]
        public decimal OrbitaAltitudeKm { get; set; }

        [Column("orbita_categoria")]
        [StringLength(3)]
        public string OrbitaCategoria { get; set; } = string.Empty;

        [Column("orbita_inclinacao", TypeName = "decimal(5, 2)")]
        public decimal OrbitaInclinacao { get; set; }
    }
}
