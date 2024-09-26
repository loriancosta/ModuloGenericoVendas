using Microsoft.EntityFrameworkCore;
using Vendas.Data.Context;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Data.Repositories.Implementations
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(VendasDbContext context) : base(context)
        {




        }

    }
}
