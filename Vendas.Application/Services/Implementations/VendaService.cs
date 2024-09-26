using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using AutoMapper;
using Vendas.Application.Dtos;

namespace Vendas.Application.Services.Implementations
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IVendaEventService _vendaEventService;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IVendaEventService vendaEventService, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _vendaEventService = vendaEventService;
            _mapper = mapper;
        }

        public async Task<VendaDto> GetVendaByIdAsync(int id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            return _mapper.Map<VendaDto>(venda);
        }

        public async Task<IEnumerable<VendaDto>> GetAllVendasAsync()
        {
            var vendas = await _vendaRepository.GetAllAsync();
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
            var venda = _mapper.Map<Venda>(vendaDto);

            await _vendaRepository.UpdateAsync(venda);
            await _vendaRepository.SaveChangesAsync();

            _vendaEventService.CompraAlterada(venda);
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
        }
    }
}
