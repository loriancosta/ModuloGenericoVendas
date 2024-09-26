using AutoMapper;
using Vendas.Application.Dtos;
using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services.Implementations
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<int> CadastrarProdutoAsync(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.AddAsync(produto);
            await _produtoRepository.SaveChangesAsync();
            return produto.Id;
        }

        public async Task<ProdutoDto> ObterProdutoPorIdAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDto>(produto);
        }
    }
}
