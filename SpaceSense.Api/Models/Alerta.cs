using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    [Table("ALERTAS")]
    public class Alerta
    {
        [Key]
        [Column("alerta_id")]
        public int AlertaId { get; set; }

        [Column("alerta_nivel")]
        [StringLength(1)]
        public string AlertaNivel { get; set; } = string.Empty;

        [Column("alerta_descricao")]
        [StringLength(500)]
        public string AlertaDescricao { get; set; } = string.Empty;

        [Column("alerta_data")]
        public DateTime AlertaData { get; set; }

        [Column("satelite_id")]
        public int SateliteId { get; set; }
        public Satelite? Satelite { get; set; }

        [Column("PLATAFORMA_plataforma_id")]
        public int PlataformaId { get; set; }
        [ForeignKey("PlataformaId")]
        public Plataforma? Plataforma { get; set; }
    }
}
