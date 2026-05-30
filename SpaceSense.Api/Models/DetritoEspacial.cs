using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    [Table("DETRITO_ESPACIAL")]
    public class DetritoEspacial : ObjetoEspacial
    {
        [Column("detrito_tamanho", TypeName = "decimal(4, 1)")]
        public decimal DetritoTamanho { get; set; }

        [Column("detrito_risco_colisao", TypeName = "decimal(5, 2)")]
        public decimal DetritoRiscoColisao { get; set; }
    }
}
