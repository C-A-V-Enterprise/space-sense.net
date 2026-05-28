using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    [Table("SATELITES")]
    public class Satelite
    {
        [Key]
        [Column("satelite_id")]
        public int SateliteId { get; set; }

        [Column("satelite_nome")]
        [StringLength(50)]
        public string SateliteNome { get; set; } = string.Empty;

        [Column("satelite_funcao")]
        [StringLength(500)]
        public string SateliteFuncao { get; set; } = string.Empty;

        [Column("satelite_status")]
        [StringLength(1)]
        public string SateliteStatus { get; set; } = string.Empty;

        [Column("satelite_data_lancamento")]
        public DateTime SateliteDataLancamento { get; set; }

        [Column("satelite_velocidade", TypeName = "decimal(10, 2)")]
        public decimal SateliteVelocidade { get; set; }

        [Column("empresa_id")]
        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }

        [Column("orbita_id")]
        public int OrbitaId { get; set; }
        public Orbita? Orbita { get; set; }
    }
}
