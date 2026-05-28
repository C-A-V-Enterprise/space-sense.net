using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceSense.Api.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("usuario_nome")]
        [StringLength(50)]
        public string UsuarioNome { get; set; } = string.Empty;

        [Column("usuario_email")]
        [StringLength(100)]
        public string UsuarioEmail { get; set; } = string.Empty;

        [Column("usuario_senha")]
        [StringLength(20)]
        public string UsuarioSenha { get; set; } = string.Empty;

        [Column("usuario_tipo")]
        [StringLength(50)]
        public string UsuarioTipo { get; set; } = string.Empty;

        [Column("plataforma_id")]
        public int PlataformaId { get; set; }
        public Plataforma? Plataforma { get; set; }
    }
}
