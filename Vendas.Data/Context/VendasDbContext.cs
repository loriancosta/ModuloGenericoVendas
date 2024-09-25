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
            modelBuilder.Entity<ItemVenda>(entity =>
            {
                entity.HasKey("_id");
                entity.Property<int>("_id").HasColumnName("Id");
                entity.Property<int>("_produtoId").HasColumnName("ProdutoId");
                entity.Property<string>("_nomeProduto").HasColumnName("NomeProduto");
                entity.Property<decimal>("_quantidade").HasColumnName("Quantidade");
                entity.Property<decimal>("_precoUnitario").HasColumnName("PrecoUnitario");
                entity.Property<decimal>("_desconto").HasColumnName("Desconto");
                entity.Property<int>("_vendaId").HasColumnName("VendaId");

                entity.HasOne<Venda>()
                      .WithMany(v => v.ItensVenda)
                      .HasForeignKey("_vendaId")
                      .HasConstraintName("FK_ItemVenda_Venda")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey("_id");
                entity.Property<int>("_id").HasColumnName("Id");
                entity.Property<string>("_numeroVenda").HasColumnName("NumeroVenda");
                entity.Property<DateTime>("_dataVenda").HasColumnName("DataVenda");
                entity.Property<int>("_clienteId").HasColumnName("ClienteId");
                entity.Property<string>("_nomeCliente").HasColumnName("NomeCliente");
            });

            base.OnModelCreating(modelBuilder);
        }



    }
}