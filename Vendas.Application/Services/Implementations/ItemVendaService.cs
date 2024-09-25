using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services.Implementations
{
    public class ItemVendaService : IItemVendaService
    {
        private readonly IItemVendaRepository _itemVendaRepository;

        public ItemVendaService(IItemVendaRepository itemVendaRepository)
        {
            _itemVendaRepository = itemVendaRepository;
        }

        public async Task<ItemVenda> GetItemVendaByIdAsync(int id)
        {
            return await _itemVendaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ItemVenda>> GetAllItensVendaAsync()
        {
            return await _itemVendaRepository.GetAllAsync();
        }

        public async Task CreateItemVendaAsync(ItemVenda itemVenda)
        {
            await _itemVendaRepository.AddAsync(itemVenda);
            await _itemVendaRepository.SaveChangesAsync();
        }

        public async Task UpdateItemVendaAsync(ItemVenda itemVenda)
        {
            await _itemVendaRepository.UpdateAsync(itemVenda);
            await _itemVendaRepository.SaveChangesAsync();
        }

        public async Task RemoveItemVendaAsync(int id)
        {
            await _itemVendaRepository.DeleteAsync(id);
            await _itemVendaRepository.SaveChangesAsync();
        }
    }
}
