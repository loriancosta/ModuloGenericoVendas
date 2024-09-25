using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;
        private readonly IVendaEventService _vendaEventService;

        public VendasController(IVendaService vendaService, IVendaEventService vendaEventService)
        {
            _vendaService = vendaService;
            _vendaEventService = vendaEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVendas()
        {
            var vendas = await _vendaService.GetAllVendasAsync();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _vendaService.GetVendaByIdAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        [HttpPost]
        public async Task<ActionResult<Venda>> CreateVenda(Venda venda)
        {
            await _vendaService.CreateVendaAsync(venda);

            // Publicar evento de venda criada
            _vendaEventService.CompraCriada(venda);

            return CreatedAtAction(nameof(GetVenda), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(int id, Venda venda)
        {
            if (id != venda.Id)
            {
                return BadRequest();
            }

            if (!await VendaExists(id))
            {
                return NotFound();
            }

            await _vendaService.UpdateVendaAsync(venda);

            _vendaEventService.CompraAlterada(venda);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelVenda(int id)
        {
            if (!await VendaExists(id))
            {
                return NotFound();
            }

            var venda = await _vendaService.GetVendaByIdAsync(id);
            venda.CancelarVenda();
            await _vendaService.UpdateVendaAsync(venda);

            _vendaEventService.CompraCancelada(venda);

            return NoContent();
        }

        private async Task<bool> VendaExists(int id)
        {
            var venda = await _vendaService.GetVendaByIdAsync(id);
            return venda != null;
        }
    }
}
