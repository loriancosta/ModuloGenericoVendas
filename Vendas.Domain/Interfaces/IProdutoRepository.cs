using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task AddAsync(Produto produto);
        Task<Produto> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
