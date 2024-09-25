using Vendas.Data.Context;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Data.Repositories.Implementations
{
    public class ItemVendaRepository : GenericRepository<ItemVenda>, IItemVendaRepository
    {
        public ItemVendaRepository(VendasDbContext context) : base(context)
        {

        }

        
    }
}
