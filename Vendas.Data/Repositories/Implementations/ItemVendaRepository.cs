using Vendas.Data.Context;
using Vendas.Data.Repositories.Interfaces;
using Vendas.Domain.Entities;

namespace Vendas.Data.Repositories.Implementations
{
    public class ItemVendaRepository : Repository<ItemVenda>, IItemVendaRepository
    {
        public ItemVendaRepository(VendasDbContext context) : base(context)
        {

        }

        
    }
}
