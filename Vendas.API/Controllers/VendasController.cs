using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Services.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Application.Dtos;
using AutoMapper;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;
        private readonly IVendaEventService _vendaEventService;
        private readonly IMapper _mapper;

        public VendasController(IVendaService vendaService, IVendaEventService vendaEventService, IMapper mapper)
        {
            _vendaService = vendaService;
            _vendaEventService = vendaEventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaDto>>> GetVendas()
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
        public async Task<ActionResult> CreateVenda([FromBody] VendaDto vendaDto)
        {
            var vendaId = await _vendaService.CreateVendaAsync(vendaDto);

            return CreatedAtAction(nameof(GetVenda), new { id = vendaId }, vendaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(int id, [FromBody] VendaDto vendaDto)
        {
            if (id != vendaDto.Id)
                return BadRequest("O ID da venda não corresponde ao ID da URL.");

            if (!await VendaExists(id))
                return NotFound();

            await _vendaService.UpdateVendaAsync(vendaDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelVenda(int id)
        {
            try
            {
                await _vendaService.DeleteVendaAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        private async Task<bool> VendaExists(int id)
        {
            var venda = await _vendaService.GetVendaByIdAsync(id);
            return venda != null;
        }
    }
}
