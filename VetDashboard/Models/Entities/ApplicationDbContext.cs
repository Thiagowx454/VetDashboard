using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VetDashboard.Models.Entities;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgendaVeterinario> AgendaVeterinarios { get; set; }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<CadastroColaborador> CadastroColaboradors { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ItemEstoque> ItemEstoques { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Procedimento> Procedimentos { get; set; }

    public virtual DbSet<Prontuario> Prontuarios { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Vacina> Vacinas { get; set; }

    public virtual DbSet<Valor> Valors { get; set; }

    public virtual DbSet<Veterinario> Veterinarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PetMedDigitalDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgendaVeterinario>(entity =>
        {
            entity.HasKey(e => e.IdAgendaVeterinario);

            entity.ToTable("AgendaVeterinario");

            entity.HasIndex(e => e.IdVeterinario, "IX_AgendaVeterinario_IdVeterinario");

            entity.HasIndex(e => e.PacienteIdPaciente, "IX_AgendaVeterinario_PacienteIdPaciente");

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.AgendaVeterinarios)
                .HasForeignKey(d => d.IdVeterinario)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PacienteIdPacienteNavigation).WithMany(p => p.AgendaVeterinarios).HasForeignKey(d => d.PacienteIdPaciente);
        });

        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.IdAgendamento);

            entity.ToTable("Agendamento");

            entity.HasIndex(e => e.IdPaciente, "IX_Agendamento_IdPaciente");

            entity.HasIndex(e => e.IdVeterinario, "IX_Agendamento_IdVeterinario");

            entity.Property(e => e.Observacoes).HasMaxLength(500);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Agendamentos).HasForeignKey(d => d.IdPaciente);

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.IdVeterinario)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<CadastroColaborador>(entity =>
        {
            entity.HasKey(e => e.IdColaborador);

            entity.ToTable("CadastroColaborador");

            entity.HasIndex(e => e.IdentityUserId, "IX_CadastroColaborador_IdentityUserId").IsUnique();

            entity.Property(e => e.Bairro).HasMaxLength(100);
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade).HasMaxLength(100);
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .HasColumnName("CPF");
            entity.Property(e => e.Endereco).HasMaxLength(200);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Rg)
                .HasMaxLength(15)
                .HasColumnName("RG");

            entity.HasOne(d => d.IdentityUser).WithOne(p => p.CadastroColaborador)
                .HasForeignKey<CadastroColaborador>(d => d.IdentityUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("Cliente");

            entity.Property(e => e.Bairro).HasMaxLength(100);
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade).HasMaxLength(100);
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .HasColumnName("CPF");
            entity.Property(e => e.Endereco).HasMaxLength(200);
            entity.Property(e => e.NomeResponsavel).HasMaxLength(100);
            entity.Property(e => e.Rg)
                .HasMaxLength(20)
                .HasColumnName("RG");
        });

        modelBuilder.Entity<ItemEstoque>(entity =>
        {
            entity.HasKey(e => e.IdProduto);

            entity.ToTable("ItemEstoque");

            entity.Property(e => e.Descricao).HasMaxLength(500);
            entity.Property(e => e.Fornecedor).HasMaxLength(100);
            entity.Property(e => e.NomeProduto).HasMaxLength(150);
            entity.Property(e => e.PrecoCusto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecoVenda).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnidadeMedida).HasMaxLength(50);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente);

            entity.ToTable("Paciente");

            entity.HasIndex(e => e.IdCliente, "IX_Paciente_IdCliente");

            entity.Property(e => e.NomeCachorro).HasMaxLength(100);
            entity.Property(e => e.Problema).HasMaxLength(500);
            entity.Property(e => e.Recomendacoes).HasMaxLength(500);
            entity.Property(e => e.SinaisVitais).HasMaxLength(500);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pacientes).HasForeignKey(d => d.IdCliente);
        });

        modelBuilder.Entity<Procedimento>(entity =>
        {
            entity.HasKey(e => e.IdProcedimento);

            entity.ToTable("Procedimento");

            entity.HasIndex(e => e.IdProduto, "IX_Procedimento_IdProduto").IsUnique();

            entity.Property(e => e.Descricao).HasMaxLength(500);
            entity.Property(e => e.NomeProcedimento).HasMaxLength(150);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdProdutoNavigation).WithOne(p => p.Procedimento)
                .HasForeignKey<Procedimento>(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Prontuario>(entity =>
        {
            entity.HasKey(e => e.IdProntuario);

            entity.ToTable("Prontuario");

            entity.HasIndex(e => e.IdAgendamento, "IX_Prontuario_IdAgendamento")
                .IsUnique()
                .HasFilter("([IdAgendamento] IS NOT NULL)");

            entity.HasIndex(e => e.IdPaciente, "IX_Prontuario_IdPaciente");

            entity.HasIndex(e => e.IdVeterinario, "IX_Prontuario_IdVeterinario");

            entity.Property(e => e.Diagnostico).HasMaxLength(1000);
            entity.Property(e => e.MotivoConsulta).HasMaxLength(500);
            entity.Property(e => e.Observacoes).HasMaxLength(1000);
            entity.Property(e => e.Tratamento).HasMaxLength(1000);

            entity.HasOne(d => d.IdAgendamentoNavigation).WithOne(p => p.Prontuario).HasForeignKey<Prontuario>(d => d.IdAgendamento);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Prontuarios).HasForeignKey(d => d.IdPaciente);

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.Prontuarios).HasForeignKey(d => d.IdVeterinario);
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.IdServico);

            entity.ToTable("Servico");

            entity.HasIndex(e => e.IdAgendamento, "IX_Servico_IdAgendamento");

            entity.HasIndex(e => e.IdProduto, "IX_Servico_IdProduto").IsUnique();

            entity.HasIndex(e => e.IdValor, "IX_Servico_IdValor").IsUnique();

            entity.HasIndex(e => e.IdVeterinario, "IX_Servico_IdVeterinario");

            entity.Property(e => e.Descricao).HasMaxLength(500);
            entity.Property(e => e.NomeServico).HasMaxLength(150);
            entity.Property(e => e.PrecoVenda).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TipoVenda).HasMaxLength(50);

            entity.HasOne(d => d.IdAgendamentoNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.IdAgendamento)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdProdutoNavigation).WithOne(p => p.Servico)
                .HasForeignKey<Servico>(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdValorNavigation).WithOne(p => p.Servico)
                .HasForeignKey<Servico>(d => d.IdValor)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.IdVeterinario)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Vacina>(entity =>
        {
            entity.HasKey(e => e.IdVacina);

            entity.ToTable("Vacina");

            entity.HasIndex(e => e.IdPaciente, "IX_Vacina_IdPaciente");

            entity.HasIndex(e => e.IdProduto, "IX_Vacina_IdProduto").IsUnique();

            entity.Property(e => e.Descricao).HasMaxLength(500);
            entity.Property(e => e.Duracao).HasMaxLength(50);
            entity.Property(e => e.NomeVacina).HasMaxLength(150);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Vacinas).HasForeignKey(d => d.IdPaciente);

            entity.HasOne(d => d.IdProdutoNavigation).WithOne(p => p.Vacina)
                .HasForeignKey<Vacina>(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Valor>(entity =>
        {
            entity.HasKey(e => e.IdValor);

            entity.ToTable("Valor");

            entity.HasIndex(e => e.IdCliente, "IX_Valor_IdCliente");

            entity.Property(e => e.CompraProdutos).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TipoPagamento).HasMaxLength(50);
            entity.Property(e => e.ValorProcedimento).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValorReceita).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValorSaida).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Valors)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Veterinario>(entity =>
        {
            entity.HasKey(e => e.IdVeterinario);

            entity.HasIndex(e => e.IdColaborador, "IX_Veterinarios_IdColaborador").IsUnique();

            entity.Property(e => e.Especialidade).HasMaxLength(100);
            entity.Property(e => e.NomeVeterinario).HasMaxLength(100);

            entity.HasOne(d => d.IdColaboradorNavigation).WithOne(p => p.Veterinario).HasForeignKey<Veterinario>(d => d.IdColaborador);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
