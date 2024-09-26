using Vendas.Application.Dtos;
using Vendas.Domain.Entities;

namespace Vendas.Application.Services.Interfaces
{
    public interface IVendaService
    {
        Task<VendaDto> GetVendaByIdAsync(int id);
        Task<IEnumerable<VendaDto>> GetAllVendasAsync();
        Task<int> CreateVendaAsync(VendaDto venda);
        Task UpdateVendaAsync(VendaDto venda);
        Task DeleteVendaAsync(int id);
    }
}
