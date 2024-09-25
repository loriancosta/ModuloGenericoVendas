using Xunit;
using FluentAssertions;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using Vendas.API.Controllers;
using Vendas.Data.Context;
using Vendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vendas.XUnit.Tests
{
    public class VendasControllerTests
    {

        private readonly VendasDbContext _context;
        private readonly VendasController _controller;

        public VendasControllerTests()
        {
            
            var options = new DbContextOptionsBuilder<VendasDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new VendasDbContext(options);
            _controller = new VendasController(_context);
        }

        [Fact]
        public async Task GetVendas_ShouldReturnEmptyList_WhenNoVendasExist()
        {
            // Act
            var result = await _controller.GetVendas();

            // Assert
            result.Value.Should().BeEmpty();
        }

        [Fact]
        public async Task CreateVenda_ShouldAddVendaSuccessfully()
        {
            
            var venda = new Venda
            {
                NumeroVenda = "123",
                Cliente = "Cliente Teste",
                Filial = "Filial Teste",
                ValorTotal = 100.0m
            };

            // Act
            var result = await _controller.CreateVenda(venda);

            // Assert
            var createdResult = result.Result as CreatedAtActionResult;
            createdResult.Should().NotBeNull();
            createdResult.Value.Should().BeEquivalentTo(venda);
        }

    }
}
