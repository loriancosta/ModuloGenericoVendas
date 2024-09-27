using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Vendas.Data.Context;
using Vendas.Domain.Entities;
using Vendas.Application.Services.Implementations;
using Vendas.Application.Services.Interfaces;
using AutoMapper;
using Vendas.Application.Dtos;
using Vendas.Data.Repositories.Implementations;
using Vendas.Domain.Interfaces;
using Vendas.Application.Events.Interfaces;

public class VendaServiceTests
{
    private readonly VendasDbContext _context;
    private readonly IVendaService _vendaService;    
    private readonly IProdutoRepository _produtoRepository;
    private readonly Mock<IItemVendaService> _itemVendaServiceMock;
    private readonly Mock<IVendaRepository> _vendaRepositoryMock;
    private readonly Mock<IVendaEvent> _vendaEventServiceMock;
    private readonly Mock<IMapper> _mapperMock;

    public VendaServiceTests()
    {
        var options = new DbContextOptionsBuilder<VendasDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        _context = new VendasDbContext(options);
        _produtoRepository = new ProdutoRepository(_context);

        // Mocando a DI
        _vendaRepositoryMock = new Mock<IVendaRepository>();
        _vendaEventServiceMock = new Mock<IVendaEvent>();
        _itemVendaServiceMock = new Mock<IItemVendaService>();

        _mapperMock = new Mock<IMapper>();

        _vendaService = new VendaService(_vendaRepositoryMock.Object, _vendaEventServiceMock.Object, _mapperMock.Object, _itemVendaServiceMock.Object);

        SeedProdutosAsync().GetAwaiter().GetResult();
    }

    private async Task SeedProdutosAsync()
    {
        var produtos = new List<Produto>
        {
            new Produto("Fone de Ouvido Bluetooth", 50, 199.99m),
            new Produto("Carregador Portátil 10000mAh", 30, 149.90m),
            new Produto("Mouse Ergonômico Sem Fio", 20, 89.99m),
            new Produto("Teclado Mecânico RGB", 15, 299.99m),
            new Produto("Câmera de Segurança Wi-Fi", 10, 349.90m),
        };

        foreach (var produto in produtos)
        {
            await _produtoRepository.AddAsync(produto);
        }

        await _produtoRepository.SaveChangesAsync();
    }

    [Fact]
    public async Task DeveCriarVendaComItensCorretamente()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        config.AssertConfigurationIsValid();

        var vendaDto = new VendaDto
        {
            NumeroVenda = "Venda001",
            DataVenda = DateTime.Now,
            ClienteId = 1,
            NomeCliente = "Cliente Teste",
            ItensVenda = 
            {
                new ItemVendaDto { ProdutoId = 1, Quantidade = 2, PrecoUnitario = 199.99m, Desconto = 0 },
                new ItemVendaDto { ProdutoId = 2, Quantidade = 1, PrecoUnitario = 149.90m, Desconto = 0 },
                new ItemVendaDto { ProdutoId = 3, Quantidade = 3, PrecoUnitario = 89.99m, Desconto = 0 },
                new ItemVendaDto { ProdutoId = 4, Quantidade = 1, PrecoUnitario = 299.99m, Desconto = 0 },
                new ItemVendaDto { ProdutoId = 5, Quantidade = 1, PrecoUnitario = 349.90m, Desconto = 0 },
            }
        };

        await _vendaService.CreateVendaAsync(vendaDto);

        var venda = await _context.Vendas.Include(v => v.ItensVenda).FirstOrDefaultAsync(v => v.NumeroVenda == vendaDto.NumeroVenda);

        Assert.NotNull(venda); // Deve inserir a venda
        Assert.Equal(5, venda.ItensVenda.Count); // Regra - 5 itens
    }
}
