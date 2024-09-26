using Xunit;
using Vendas.Application.Services.Implementations;
using Vendas.Domain.Entities;
using Moq;
using Vendas.Application.Services.Interfaces;
using Vendas.Application.Dtos;

namespace Vendas.Tests
{
    public class VendaServiceTests
    {
        private readonly Mock<IProdutoService> _produtoServiceMock;

        public VendaServiceTests()
        {
            _produtoServiceMock = new Mock<IProdutoService>();
        }

        [Fact]
        public async Task DeveCalcularOValorTotalDaVendaCorretamente_ComProdutosCadastrados()
        {

        }
    }
}
