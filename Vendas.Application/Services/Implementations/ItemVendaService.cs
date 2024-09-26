using AutoMapper;
using Vendas.Application.Dtos;
using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services.Implementations
{
    public class ItemVendaService : IItemVendaService
    {
        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IItemVendaEventService _itemVendaEventService;
        private readonly IMapper _mapper;

        public ItemVendaService(IItemVendaRepository itemVendaRepository, IItemVendaEventService itemVendaEventService, IMapper mapper)
        {
            _itemVendaRepository = itemVendaRepository;
            _itemVendaEventService = itemVendaEventService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemVendaDto>> GetAllItensVendaAsync()
        {
            var itensVenda = await _itemVendaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemVendaDto>>(itensVenda);
        }

        public async Task<ItemVendaDto> GetItemVendaByIdAsync(int id)
        {
            var itemVenda = await _itemVendaRepository.GetByIdAsync(id);
            return _mapper.Map<ItemVendaDto>(itemVenda);
        }

        public async Task<int> CreateItemVendaAsync(ItemVendaDto itemVendaDto)
        {
            var itemVenda = _mapper.Map<ItemVenda>(itemVendaDto);

            await _itemVendaRepository.AddAsync(itemVenda);
            await _itemVendaRepository.SaveChangesAsync();

            _itemVendaEventService.ItemCriado(itemVenda);

            return itemVenda.Id;
        }

        public async Task UpdateItemVendaAsync(ItemVendaDto itemVendaDto)
        {
            var itemVenda = _mapper.Map<ItemVenda>(itemVendaDto);
            var itemExistente = await _itemVendaRepository.GetByIdAsync(itemVenda.Id);

            await _itemVendaRepository.UpdateAsync(itemVenda);
            await _itemVendaRepository.SaveChangesAsync();

            _itemVendaEventService.ItemAlterado(itemVenda);
        }

        public async Task DeleteItemVendaAsync(int id)
        {
            var itemExistente = await _itemVendaRepository.GetByIdAsync(id);

            await _itemVendaRepository.DeleteAsync(id);
            await _itemVendaRepository.SaveChangesAsync();

            _itemVendaEventService.ItemCancelado(itemExistente);
        }
    }
}
