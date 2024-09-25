using Vendas.Domain.Entities;

namespace Vendas.Application.Services.Interfaces
{
    public interface IVendaService
    {
        Task<Venda> GetVendaByIdAsync(int id);
        Task<IEnumerable<Venda>> GetAllVendasAsync();
        Task CreateVendaAsync(Venda venda);
        Task UpdateVendaAsync(Venda venda);
        Task DeleteVendaAsync(int id);
    }
}
