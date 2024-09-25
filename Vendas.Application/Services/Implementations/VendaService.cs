using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services.Implementations
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<Venda> GetVendaByIdAsync(int id)
        {
            return await _vendaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Venda>> GetAllVendasAsync()
        {
            return await _vendaRepository.GetAllAsync();
        }

        public async Task CreateVendaAsync(Venda venda)
        {
            await _vendaRepository.AddAsync(venda);
            await _vendaRepository.SaveChangesAsync();
        }

        public async Task UpdateVendaAsync(Venda venda)
        {
            await _vendaRepository.UpdateAsync(venda);
            await _vendaRepository.SaveChangesAsync();
        }

        public async Task DeleteVendaAsync(int id)
        {
            await _vendaRepository.DeleteAsync(id);
            await _vendaRepository.SaveChangesAsync();
        }
    }
}
