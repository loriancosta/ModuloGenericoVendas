using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dtos;
using Vendas.Application.Services.Interfaces;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduto([FromBody] ProdutoDto produtoDto)
        {
            var produtoId = await _produtoService.CreateProdutoAsync(produtoDto);
            return CreatedAtAction("Produto", new { id = produtoId }, produtoDto);
        }

    }
}
