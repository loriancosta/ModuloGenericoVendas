using Vendas.Application.Dtos;

namespace Vendas.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<int> CreateProdutoAsync(ProdutoDto produtoDto);

    }
}
