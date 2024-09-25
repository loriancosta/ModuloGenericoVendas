using Microsoft.AspNetCore.Mvc;
using Vendas.Data.Repositories.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Services.Implementations;
using Vendas.Domain.Services.Interfaces;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensVendaController : ControllerBase
    {

        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IItemVendaEventService _itemVendaEventService;

        public ItensVendaController(IItemVendaRepository itemVendaRepository, IItemVendaEventService itemVendaEventService)
        {
            _itemVendaRepository = itemVendaRepository;
            _itemVendaEventService = itemVendaEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemVenda>>> GetItensVenda()
        {
            var itensVenda = await _itemVendaRepository.GetAllAsync();
            return Ok(itensVenda);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemVenda>> GetItemVenda(int id)
        {
            var itemVenda = await _itemVendaRepository.GetByIdAsync(id);
            
            if (itemVenda == null)
            {
                return NotFound();
            }

            return Ok(itemVenda);
        }

        [HttpPost]
        public async Task<ActionResult<ItemVenda>> CreateItemVenda(ItemVenda itemVenda)
        {
            await _itemVendaRepository.AddAsync(itemVenda);
            await _itemVendaRepository.SaveChangesAsync();

            _itemVendaEventService.ItemCriado(itemVenda);

            return CreatedAtAction(nameof(GetItemVenda), new { id = itemVenda.Id }, itemVenda);
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

            _itemVendaRepository.Update(itemVenda);
            await _itemVendaRepository.SaveChangesAsync();

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

            var itemVenda = await _itemVendaRepository.GetByIdAsync(id);
            _itemVendaRepository.Remove(itemVenda);
            await _itemVendaRepository.SaveChangesAsync();

            _itemVendaEventService.ItemCancelado(itemVenda);

            return NoContent();
        }

        private async Task<bool> ItemVendaExists(int id)
        {
            var itemVenda = await _itemVendaRepository.GetByIdAsync(id);
            return itemVenda != null;
        }

    }
}
