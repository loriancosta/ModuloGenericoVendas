using Vendas.Domain.Entities;

namespace Vendas.Application.Events.Interfaces
{
    public interface IVendaEvent
    {
        void CompraCriada(Venda venda);
        void CompraAlterada(Venda venda);
        void CompraCancelada(Venda venda);
    }
}
