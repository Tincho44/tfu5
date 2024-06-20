using Microsoft.EntityFrameworkCore;

namespace MiProyectoAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Participante>()
                .HasKey(p => p.Ci);

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Nombre)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Descripcion)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Disciplina>()
                .Property(d => d.Nombre)
                .HasColumnType("TEXT");
        }
    }
}
