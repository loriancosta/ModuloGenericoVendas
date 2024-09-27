using AutoMapper;
using Vendas.Application.Dtos;
using Vendas.Application.Events.Interfaces;
using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services.Implementations
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IVendaEvent _vendaEventService;
        private readonly IMapper _mapper;
        private readonly IItemVendaService _itemVendaService;

        public VendaService(IVendaRepository vendaRepository, IVendaEvent vendaEventService, IMapper mapper, IItemVendaService itemVendaService)
        {
            _vendaRepository = vendaRepository;
            _vendaEventService = vendaEventService;
            _mapper = mapper;
            _itemVendaService = itemVendaService;
        }

        public async Task<VendaDto> GetVendaByIdAsync(int id)
        {
            var venda = await _vendaRepository.GetVendaComItensByIdAsync(id);

            if (venda == null)
                throw new KeyNotFoundException("Venda não encontrada.");

            return _mapper.Map<VendaDto>(venda);
        }

        public async Task<IEnumerable<VendaDto>> GetAllVendasAsync()
        {
            var vendas = await _vendaRepository.GetVendasComItensAsync();

            if (vendas == null || !vendas.Any())
                throw new KeyNotFoundException("Nenhuma venda encontrada.");

            return _mapper.Map<IEnumerable<VendaDto>>(vendas);
        }

        public async Task<int> CreateVendaAsync(VendaDto vendaDto)
        {
            try
            {
                var venda = _mapper.Map<Venda>(vendaDto);

                await _vendaRepository.AddAsync(venda);
                await _vendaRepository.SaveChangesAsync();

                _vendaEventService.CompraCriada(venda);

                return venda.Id;

            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }

        public async Task UpdateVendaAsync(VendaDto vendaDto)
        {
            var vendaExistente = await _vendaRepository.GetByIdAsync(vendaDto.Id);

            if (vendaExistente == null)
                throw new Exception("Venda não encontrada");

            vendaExistente.NumeroVenda = vendaDto.NumeroVenda;
            vendaExistente.DataVenda = vendaDto.DataVenda;
            vendaExistente.ClienteId = vendaDto.ClienteId;
            vendaExistente.NomeCliente = vendaDto.NomeCliente;
            vendaExistente.IsCancelado = vendaDto.IsCancelado;

            // Atualiza a venda
            await _vendaRepository.UpdateAsync(vendaExistente);

            // Atualiza os itens da venda
            foreach (var itemDto in vendaDto.ItensVenda)
            {
                await _itemVendaService.UpdateItemVendaAsync(itemDto);
            }

            await _vendaRepository.SaveChangesAsync();

            _vendaEventService.CompraAlterada(vendaExistente);
        }


        public async Task DeleteVendaAsync(int id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            if (venda == null)
                throw new KeyNotFoundException("Venda não encontrada.");

            await _vendaRepository.UpdateAsync(venda);
            await _vendaRepository.SaveChangesAsync();

            _vendaEventService.CompraCancelada(venda);
        }

        public async Task CancelVendaAsync(int vendaId)
        {
            var venda = await _vendaRepository.GetByIdAsync(vendaId);
            if (venda == null)
                throw new Exception("Venda não encontrada");

            venda.IsCancelado = true;

            await _vendaRepository.UpdateAsync(venda);
            await _vendaRepository.SaveChangesAsync();

            _vendaEventService.CompraCancelada(venda);
        }

    }
}
