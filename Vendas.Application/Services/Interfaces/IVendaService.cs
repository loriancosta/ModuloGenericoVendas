using Vendas.Application.Dtos;

namespace Vendas.Application.Services.Interfaces
{
    public interface IVendaService
    {
        Task<VendaDto> GetVendaByIdAsync(int id);
        Task<IEnumerable<VendaDto>> GetAllVendasAsync();
        Task<int> CreateVendaAsync(VendaDto venda);
        Task UpdateVendaAsync(VendaDto venda);
        Task DeleteVendaAsync(int id);
        Task CancelVendaAsync(int vendaId);
    }
}
