using Vendas.Domain.Entities;

namespace Vendas.Application.Events.Interfaces
{
    public interface IItemVendaEvent
    {
        void ItemCriado(ItemVenda itemVenda);
        void ItemAlterado(ItemVenda itemVenda);
        void ItemCancelado(ItemVenda itemVenda);
    }
}
