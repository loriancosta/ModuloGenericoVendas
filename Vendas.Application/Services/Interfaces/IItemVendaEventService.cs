using Vendas.Domain.Entities;

namespace Vendas.Application.Services.Interfaces
{
    public interface IItemVendaEventService
    {
        void ItemCriado(ItemVenda itemVenda);
        void ItemAlterado(ItemVenda itemVenda);
        void ItemCancelado(ItemVenda itemVenda);
    }
}
