using AutoMapper;
using Vendas.Application.Dtos;
using Vendas.Application.Events.Interfaces;
using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services.Implementations
{
    public class ItemVendaService : IItemVendaService
    {
        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IItemVendaEvent _itemVendaEventService;
        private readonly IMapper _mapper;

        public ItemVendaService(IItemVendaRepository itemVendaRepository, IItemVendaEvent itemVendaEventService, IMapper mapper)
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
            var itemExistente = await _itemVendaRepository.GetByIdAsync(itemVendaDto.Id);
            if (itemExistente == null)
                throw new Exception("Item de venda não encontrado");

            var itemAtualizado = _mapper.Map(itemVendaDto, itemExistente);

            await _itemVendaRepository.UpdateAsync(itemAtualizado);
            await _itemVendaRepository.SaveChangesAsync();

            _itemVendaEventService.ItemAlterado(itemAtualizado);
        }

        public async Task DeleteItemVendaAsync(int id)
        {
            var itemExistente = await _itemVendaRepository.GetByIdAsync(id);
            if (itemExistente == null)
                throw new Exception("Item de venda não encontrado");

            await _itemVendaRepository.DeleteAsync(id);
            await _itemVendaRepository.SaveChangesAsync();

            _itemVendaEventService.ItemCancelado(itemExistente);
        }
    }
}
