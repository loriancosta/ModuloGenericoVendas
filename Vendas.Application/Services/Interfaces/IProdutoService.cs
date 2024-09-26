using Vendas.Application.Dtos;

namespace Vendas.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<int> CadastrarProdutoAsync(ProdutoDto produtoDto);
        Task<ProdutoDto> ObterProdutoPorIdAsync(int id);
    }
}
