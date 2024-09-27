using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dtos;
using Vendas.Application.Events.Interfaces;
using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;
        private readonly IVendaEvent _vendaEventService;

        public VendasController(IVendaService vendaService, IVendaEvent vendaEventService)
        {
            _vendaService = vendaService;
            _vendaEventService = vendaEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaDto>>> GetVendas()
        {
            var vendas = await _vendaService.GetAllVendasAsync();
            if (vendas == null || !vendas.Any())
            {
                return NotFound(new { message = "Nenhuma venda encontrada." });
            }

            return Ok(new { message = "Vendas recuperadas com sucesso.", vendas });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _vendaService.GetVendaByIdAsync(id);
            if (venda == null)
            {
                return NotFound(new { message = $"Venda com ID {id} não encontrada." });
            }

            return Ok(new { message = "Venda recuperada com sucesso.", venda });
        }

        [HttpPost]
        public async Task<ActionResult> CreateVenda([FromBody] VendaDto vendaDto)
        {
            var vendaId = await _vendaService.CreateVendaAsync(vendaDto);

            return CreatedAtAction(nameof(GetVenda), new { id = vendaId }, new { message = "Venda criada com sucesso.", vendaId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(int id, [FromBody] VendaDto vendaDto)
        {
            if (id != vendaDto.Id)
                return BadRequest(new { message = "O ID da venda não corresponde ao ID da URL." });

            if (!await VendaExists(id))
                return NotFound(new { message = $"Venda {id} não encontrada." });

            await _vendaService.UpdateVendaAsync(vendaDto);

            return Ok(new { message = "Venda atualizada com sucesso." });
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelVenda(int id)
        {
            try
            {
                await _vendaService.CancelVendaAsync(id);
                return Ok(new { message = "Venda cancelada com sucesso." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Venda {id} não encontrada para cancelamento." });
            }
        }

        private async Task<bool> VendaExists(int id)
        {
            var venda = await _vendaService.GetVendaByIdAsync(id);
            return venda != null;
        }
    }
}
