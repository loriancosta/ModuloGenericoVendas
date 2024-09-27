using Serilog;
using Vendas.Domain.Entities;
using Vendas.Application.Events.Interfaces;

namespace Vendas.Application.Events.Implementations
{
    public class VendaEvent : IVendaEvent
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
    }
}
