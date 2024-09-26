using Xunit;
using Vendas.Data.Context;
using Vendas.Domain.Entities;
using Vendas.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;

namespace Vendas.Tests
{
    public class ProdutoRepositoryTests
    {
        private readonly VendasDbContext _context;
        private readonly IMapper _mapper;

        public ProdutoRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<VendasDbContext>()
                .UseInMemoryDatabase(databaseName: "VendasTestDb")
                .Options;

            _context = new VendasDbContext(options);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ProdutoDto, Produto>(); });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task DeveInserirProdutosCorretamente()
        {
            // Lista de produtos a serem inseridos
            var produtosDto = new[]
            {
                new ProdutoDto { Descricao = "Fone de Ouvido Bluetooth", Quantidade = 50, PrecoUnitario = 199.99m },
                new ProdutoDto { Descricao = "Carregador Portátil 10000mAh", Quantidade = 30, PrecoUnitario = 149.90m },
                new ProdutoDto { Descricao = "Mouse Ergonômico Sem Fio", Quantidade = 20, PrecoUnitario = 89.99m },
                new ProdutoDto { Descricao = "Teclado Mecânico RGB", Quantidade = 15, PrecoUnitario = 299.99m },
                new ProdutoDto { Descricao = "Câmera de Segurança Wi-Fi", Quantidade = 10, PrecoUnitario = 349.90m },
                new ProdutoDto { Descricao = "Smartwatch Fitness", Quantidade = 25, PrecoUnitario = 399.99m },
                new ProdutoDto { Descricao = "Cabo USB-C 2 metros", Quantidade = 100, PrecoUnitario = 29.99m },
                new ProdutoDto { Descricao = "Adaptador HDMI para USB-C", Quantidade = 40, PrecoUnitario = 59.90m },
                new ProdutoDto { Descricao = "Monitor LED Full HD 24", Quantidade = 8, PrecoUnitario = 849.90m },
                new ProdutoDto { Descricao = "Webcam Full HD 1080p", Quantidade = 20, PrecoUnitario = 199.90m },
                new ProdutoDto { Descricao = "SSD Externo 1TB", Quantidade = 15, PrecoUnitario = 499.99m },
                new ProdutoDto { Descricao = "Hub USB 3.0 com 4 Portas", Quantidade = 50, PrecoUnitario = 99.90m },
                new ProdutoDto { Descricao = "Carregador Rápido USB-C 20W", Quantidade = 60, PrecoUnitario = 69.90m },
                new ProdutoDto { Descricao = "Smart Speaker com Assistente Virtual", Quantidade = 30, PrecoUnitario = 229.99m },
                new ProdutoDto { Descricao = "Power Bank Solar", Quantidade = 25, PrecoUnitario = 159.99m },
                new ProdutoDto { Descricao = "Drone com Câmera HD", Quantidade = 5, PrecoUnitario = 1299.99m },
                new ProdutoDto { Descricao = "Ring Light com Tripé", Quantidade = 40, PrecoUnitario = 149.90m },
                new ProdutoDto { Descricao = "Headset Gamer com Microfone", Quantidade = 35, PrecoUnitario = 279.90m },
                new ProdutoDto { Descricao = "Leitor de Cartão de Memória", Quantidade = 50, PrecoUnitario = 49.99m },
                new ProdutoDto { Descricao = "Caixa de Som Bluetooth", Quantidade = 20, PrecoUnitario = 199.99m }
            };

            // Act - Converte ProdutoDto para Produto e insere no banco de dados
            var produtos = _mapper.Map<Produto[]>(produtosDto);
            await _context.Produtos.AddRangeAsync(produtos);
            await _context.SaveChangesAsync();

            // Assert - Verifica se todos os produtos foram inseridos corretamente
            var produtosInseridos = await _context.Produtos.ToListAsync();

            // Testando algumas regras
            Assert.Equal(20, produtosInseridos.Count);            
            Assert.Contains(produtosInseridos, p => p.Descricao == "Fone de Ouvido Bluetooth");
            Assert.Contains(produtosInseridos, p => p.Descricao == "Caixa de Som Bluetooth");
        }
    }
}
