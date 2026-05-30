using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Models;

namespace SpaceSense.Api.Data
{
    public class SatGuardDbContext : DbContext
    {
        public SatGuardDbContext(DbContextOptions<SatGuardDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Orbita> Orbitas { get; set; }
        public DbSet<ObjetoEspacial> ObjetosEspaciais { get; set; }
        public DbSet<Satelite> Satelites { get; set; }
        public DbSet<DetritoEspacial> DetritosEspaciais { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do Value Object (Objeto Embutido)
            modelBuilder.Entity<Empresa>().OwnsOne(e => e.EnderecoSede);

            // Configuração da Herança TPT (Table-Per-Type)
            modelBuilder.Entity<ObjetoEspacial>().UseTptMappingStrategy();
        }
    }
}
