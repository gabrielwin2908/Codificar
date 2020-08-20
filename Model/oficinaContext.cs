using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Funcionarios.Model
{
    public partial class oficinaContext : DbContext
    {
        public oficinaContext()
        {
        }

        public oficinaContext(DbContextOptions<oficinaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Servicos> Servicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=GABRIELPC;Initial Catalog=oficina;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicos>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PK__SERVICOS__8112345F8571F441");

                entity.ToTable("SERVICOS");

                entity.Property(e => e.CodCliente).HasColumnName("COD_CLIENTE");

                entity.Property(e => e.DataOrcamento)
                    .HasColumnName("DATA_ORCAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoOrcamento)
                    .HasColumnName("DESCRICAO_ORCAMENTO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCliente)
                    .HasColumnName("NOME_CLIENTE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorOrcado)
                    .HasColumnName("VALOR_ORCADO")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Vendedor)
                    .HasColumnName("VENDEDOR")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
