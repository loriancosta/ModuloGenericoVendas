using Serilog;
using Vendas.Domain.Entities;
using Vendas.Application.Services.Interfaces;

namespace Vendas.Application.Services.Implementations
{
    public class VendaEventService : IVendaEventService
    {

        public void CompraCriada(Venda venda)
        {
            Log.Information($"CompraCriada - Venda: {venda.NumeroVenda} - Cliente: {venda.ClienteId}");
        }

        public void CompraAlterada(Venda venda)
        {
            Log.Information($"CompraAlterada - Venda: {venda.NumeroVenda}");
        }

        public void CompraCancelada(Venda venda)
        {
            Log.Information($"CompraCancelada - Venda: {venda.NumeroVenda}");
        }

        public void ItemCancelado(ItemVenda itemVenda)
        {
            Log.Information($"ItemCancelado - O item {itemVenda.ProdutoId}");
        }
    }
}
