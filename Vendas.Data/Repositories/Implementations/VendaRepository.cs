using Microsoft.EntityFrameworkCore;
using Vendas.Data.Context;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Data.Repositories.Implementations
{
    public class VendaRepository : GenericRepository<Venda>, IVendaRepository
    {
        public VendaRepository(VendasDbContext context) : base(context)
        {

        }

        public async Task<Venda> GetVendaComItensByIdAsync(int id)
        {
            return await _context.Vendas
                .Include(v => v.ItensVenda)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Venda>> GetVendasComItensAsync()
        {
            return await _context.Vendas
                .Include(v => v.ItensVenda)
                .ToListAsync();
        }
    }

}
