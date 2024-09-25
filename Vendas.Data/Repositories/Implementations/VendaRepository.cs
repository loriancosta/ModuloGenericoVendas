using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Data.Context;
using Vendas.Data.Repositories.Interfaces;
using Vendas.Domain.Entities;

namespace Vendas.Data.Repositories.Implementations
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(VendasDbContext context) : base(context)
        {



        }

        
    }

}
