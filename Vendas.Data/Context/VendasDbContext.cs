using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;

namespace Vendas.Data.Context
{
    public class VendasDbContext : DbContext
    {
        public VendasDbContext(DbContextOptions<VendasDbContext> options) : base(options)
        {

        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ItemVenda
            modelBuilder.Entity<ItemVenda>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                entity.Property(e => e.ProdutoId).HasColumnName("ProdutoId").IsRequired();
                entity.Property(e => e.NomeProduto).HasColumnName("NomeProduto").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Quantidade).HasColumnName("Quantidade").HasColumnType("decimal(18,2)");
                entity.Property(e => e.PrecoUnitario).HasColumnName("PrecoUnitario").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Desconto).HasColumnName("Desconto").HasColumnType("decimal(18,2)");
                entity.Property(e => e.VendaId).HasColumnName("VendaId").IsRequired();

                entity.HasOne<Venda>().WithMany(v => v.ItensVenda)
                      .HasForeignKey(e => e.VendaId)
                      .HasConstraintName("FK_ItemVenda_Venda")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Venda
            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                entity.Property(e => e.NumeroVenda).HasColumnName("NumeroVenda").HasMaxLength(100).IsRequired();
                entity.Property(e => e.DataVenda).HasColumnName("DataVenda").IsRequired();
                entity.Property(e => e.ClienteId).HasColumnName("ClienteId").IsRequired();
                entity.Property(e => e.NomeCliente).HasColumnName("NomeCliente").HasMaxLength(100).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
