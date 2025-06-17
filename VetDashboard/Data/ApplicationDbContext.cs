using Microsoft.EntityFrameworkCore;
using VetDashboard.Models.Entities;

namespace VetDashboard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações da entidade Consulta
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Valor).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Veterinario)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.VeterinarioId);

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.AnimalId);
            });

            // Configurações da entidade Animal
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Especie).HasMaxLength(50);
                entity.Property(e => e.Raca).HasMaxLength(50);

                entity.HasOne(d => d.Proprietario)
                    .WithMany(p => p.Animais)
                    .HasForeignKey(d => d.ProprietarioId);
            });

            // Configurações da entidade Veterinario
            modelBuilder.Entity<Veterinario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.CRM).HasMaxLength(20);
                entity.Property(e => e.Especialidade).HasMaxLength(100);
            });

            // Configurações da entidade Proprietario
            modelBuilder.Entity<Proprietario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Telefone).HasMaxLength(20);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}