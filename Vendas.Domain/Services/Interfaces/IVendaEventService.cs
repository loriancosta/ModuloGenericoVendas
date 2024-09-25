using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Services.Interfaces
{
    public interface IVendaEventService
    {
        void CompraCriada(Venda venda);
        void CompraAlterada(Venda venda);
        void CompraCancelada(Venda venda);
    }
}
