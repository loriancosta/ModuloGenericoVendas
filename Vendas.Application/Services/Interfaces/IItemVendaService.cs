using Vendas.Domain.Entities;

namespace Vendas.Application.Services.Interfaces
{
    public interface IItemVendaService
    {
        Task<ItemVenda> GetItemVendaByIdAsync(int id);
        Task<IEnumerable<ItemVenda>> GetAllItensVendaAsync();
        Task CreateItemVendaAsync(ItemVenda itemVenda);
        Task UpdateItemVendaAsync(ItemVenda itemVenda);
        Task RemoveItemVendaAsync(int id);
    }
}
