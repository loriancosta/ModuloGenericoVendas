using Serilog;
using Vendas.Domain.Entities;
using Vendas.Application.Services.Interfaces;

namespace Vendas.Application.Services.Implementations
{
    public class ItemVendaEventService : IItemVendaEventService
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