using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpaceSense.Api.Models
{
    [Owned]
    public class Endereco
    {
        [Column("endereco_rua")]
        [StringLength(100)]
        public string Rua { get; set; } = string.Empty;

        [Column("endereco_cidade")]
        [StringLength(50)]
        public string Cidade { get; set; } = string.Empty;

        [Column("endereco_estado")]
        [StringLength(50)]
        public string Estado { get; set; } = string.Empty;

        [Column("endereco_cep")]
        [StringLength(20)]
        public string Cep { get; set; } = string.Empty;
    }
}
