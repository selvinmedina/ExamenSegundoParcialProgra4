using Microsoft.EntityFrameworkCore;

namespace ExamenSelvinMedina.Infrastucture.Universidad
{
    public partial class UniversidadDbContext : DbContext
    {
        public UniversidadDbContext()
        {
        }

        public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaestroExamen> MaestroExamen { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaestroExamen>(entity =>
            {
                entity.HasKey(e => e.Ncuenta);

                entity.Property(e => e.Ncuenta)
                    .ValueGeneratedNever()
                    .HasColumnName("NCuenta");

                entity.Property(e => e.Carrera).HasMaxLength(50);

                entity.Property(e => e.NombreCompleto).HasMaxLength(50);

                entity.Property(e => e.Profesion).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
