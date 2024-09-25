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


    }

}
