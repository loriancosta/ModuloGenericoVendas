using Vendas.Application.Dtos;
using Vendas.Domain.Entities;

namespace Vendas.Application.Services.Interfaces
{
    public interface IItemVendaService
    {
        Task<ItemVendaDto> GetItemVendaByIdAsync(int id);
        Task<IEnumerable<ItemVendaDto>> GetAllItensVendaAsync();
        Task<int> CreateItemVendaAsync(ItemVendaDto itemVenda);
        Task UpdateItemVendaAsync(ItemVendaDto itemVenda);
        Task DeleteItemVendaAsync(int id);
    }
}
