using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensVendaController : ControllerBase
    {
        private readonly IItemVendaService _itemVendaService;
        private readonly IItemVendaEventService _itemVendaEventService;

        public ItensVendaController(IItemVendaService itemVendaService, IItemVendaEventService itemVendaEventService)
        {
            _itemVendaService = itemVendaService;
            _itemVendaEventService = itemVendaEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemVenda>>> GetItensVenda()
        {
            var itensVenda = await _itemVendaService.GetAllItensVendaAsync();
            return Ok(itensVenda);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemVenda>> GetItemVenda(int id)
        {
            var itemVenda = await _itemVendaService.GetItemVendaByIdAsync(id);

            if (itemVenda == null)
            {
                return NotFound();
            }

            return Ok(itemVenda);
        }

        [HttpPost]
        public async Task<ActionResult<ItemVenda>> CreateItemVenda(ItemVenda itemVenda)
        {
            await _itemVendaService.CreateItemVendaAsync(itemVenda);
            _itemVendaEventService.ItemCriado(itemVenda);

            return CreatedAtAction(nameof(GetItemVenda), new { id = itemVenda.VendaId }, itemVenda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemVenda(int id, ItemVenda itemVenda)
        {
            if (id != itemVenda.Id)
            {
                return BadRequest();
            }

            if (!await ItemVendaExists(id))
            {
                return NotFound();
            }

            await _itemVendaService.UpdateItemVendaAsync(itemVenda);
            _itemVendaEventService.ItemAlterado(itemVenda);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelItemVenda(int id)
        {
            if (!await ItemVendaExists(id))
            {
                return NotFound();
            }

            var itemVenda = await _itemVendaService.GetItemVendaByIdAsync(id);
            await _itemVendaService.RemoveItemVendaAsync(id);

            _itemVendaEventService.ItemCancelado(itemVenda);

            return NoContent();
        }

        private async Task<bool> ItemVendaExists(int id)
        {
            var itemVenda = await _itemVendaService.GetItemVendaByIdAsync(id);
            return itemVenda != null;
        }
    }
}
