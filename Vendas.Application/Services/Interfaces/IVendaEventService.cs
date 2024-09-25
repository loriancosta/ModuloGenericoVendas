using Vendas.Domain.Entities;

namespace Vendas.Application.Services.Interfaces
{
    public interface IVendaEventService
    {
        void CompraCriada(Venda venda);
        void CompraAlterada(Venda venda);
        void CompraCancelada(Venda venda);
    }
}
