using Microsoft.EntityFrameworkCore;
using Vendas.Data.Context;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Data.Repositories.Implementations
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly VendasDbContext _context;

        public ProdutoRepository(VendasDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
