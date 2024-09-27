using Serilog;
using Vendas.Domain.Entities;
using Vendas.Application.Events.Interfaces;

namespace Vendas.Application.Events.Implementations
{
    public class ItemVendaEvent : IItemVendaEvent
    {
        public void ItemCriado(ItemVenda itemVenda)
        {
            Log.Information($"ItemCriado - Venda: {itemVenda.VendaId} - Item: {itemVenda.ProdutoId}");
        }

        public void ItemAlterado(ItemVenda itemVenda)
        {
            Log.Information($"ItemAlterado - Venda: {itemVenda.VendaId} - Item: {itemVenda.ProdutoId}");
        }

        public void ItemCancelado(ItemVenda itemVenda)
        {
            Log.Information($"ItemCancelado - Venda: {itemVenda.VendaId} - Item: {itemVenda.ProdutoId}");
        }
    }
}