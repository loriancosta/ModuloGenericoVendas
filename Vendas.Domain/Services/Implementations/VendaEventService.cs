using Serilog;
using Vendas.Domain.Entities;
using Vendas.Domain.Services.Interfaces;

namespace Vendas.Domain.Services.Implementations
{
    public class VendaEventService : IVendaEventService
    {

        public void CompraCriada(Venda venda)
        {
            Log.Information($"CompraCriada - Venda: {venda.ObterNumeroVenda()} - Cliente: {venda.ObterClienteId()}");
        }

        public void CompraAlterada(Venda venda)
        {
            Log.Information($"CompraAlterada - Venda: {venda.ObterNumeroVenda()}");
        }

        public void CompraCancelada(Venda venda)
        {
            Log.Information($"CompraCancelada - Venda: {venda.ObterNumeroVenda()}");
        }

        public void ItemCancelado(ItemVenda itemVenda)
        {
            Log.Information($"ItemCancelado - O item {itemVenda.ObterProdutoId()}");
        }
    }
}
