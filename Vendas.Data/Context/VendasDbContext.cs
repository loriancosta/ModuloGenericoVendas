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
            modelBuilder.Entity<Venda>()
                .HasMany(v => v.ItensVenda)
                .WithOne()
                .HasForeignKey(i => i.VendaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}