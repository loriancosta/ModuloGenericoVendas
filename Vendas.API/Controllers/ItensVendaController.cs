using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dtos;
using Vendas.Application.Services.Interfaces;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensVendaController : ControllerBase
    {
        private readonly IItemVendaService _itemVendaService;

        public ItensVendaController(IItemVendaService itemVendaService)
        {
            _itemVendaService = itemVendaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemVendaDto>>> GetItensVenda()
        {
            var itensVenda = await _itemVendaService.GetAllItensVendaAsync();
            return Ok(itensVenda);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemVendaDto>> GetItemVenda(int id)
        {
            var itemVenda = await _itemVendaService.GetItemVendaByIdAsync(id);

            if (itemVenda == null)
                return NotFound();

            return Ok(itemVenda);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItemVenda([FromBody] ItemVendaDto itemVendaDto)
        {
            var itemVendaId = await _itemVendaService.CreateItemVendaAsync(itemVendaDto);
            return CreatedAtAction(nameof(GetItemVenda), new { id = itemVendaId }, itemVendaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemVenda(int id, [FromBody] ItemVendaDto itemVendaDto)
        {
            if (id != itemVendaDto.Id)
                return BadRequest("O ID informado não corresponde ao ID do item.");

            await _itemVendaService.UpdateItemVendaAsync(itemVendaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemVenda(int id)
        {
            await _itemVendaService.DeleteItemVendaAsync(id);
            return NoContent();
        }
    }
}
