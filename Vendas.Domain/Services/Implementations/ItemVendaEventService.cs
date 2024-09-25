using Serilog;
using Vendas.Domain.Entities;
using Vendas.Domain.Services.Interfaces;

namespace Vendas.Domain.Services.Implementations
{
    public class ItemVendaEventService : IItemVendaEventService
    {
        public void ItemCriado(ItemVenda itemVenda)
        {
            Log.Information($"ItemCriado - Venda: {itemVenda.ObterVendaId()} - Item: {itemVenda.ObterProdutoId()}");
        }

        public void ItemAlterado(ItemVenda itemVenda)
        {
            Log.Information($"ItemAlterado - Venda: {itemVenda.ObterVendaId()} - Item: {itemVenda.ObterProdutoId()}");
        }

        public void ItemCancelado(ItemVenda itemVenda)
        {
            Log.Information($"ItemCancelado - Venda: {itemVenda.ObterVendaId()} - Item: {itemVenda.ObterProdutoId()}");
        }
    }
}