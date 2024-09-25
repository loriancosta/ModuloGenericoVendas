using Microsoft.AspNetCore.Mvc;
using Vendas.Data.Repositories.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Services.Interfaces;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {


        private readonly IVendaRepository _vendaRepository;
        private readonly IVendaEventService _vendaEventService;

        public VendasController(IVendaRepository vendaRepository, IVendaEventService vendaEventService)
        {
            _vendaRepository = vendaRepository;
            _vendaEventService = vendaEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVendas()
        {
            var vendas = await _vendaRepository.GetAllAsync();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }
        [HttpPost]
        public async Task<ActionResult<Venda>> CreateVenda(Venda venda)
        {
            await _vendaRepository.AddAsync(venda);
            await _vendaRepository.SaveChangesAsync();

            // Publicar evento de venda criada
            _vendaEventService.CompraCriada(venda);

            return CreatedAtAction(nameof(GetVenda), new { id = venda.ObterId() }, venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(int id, Venda venda)
        {
            if (id != venda.ObterId())
            {
                return BadRequest();
            }

            if (!await VendaExists(id))
            {
                return NotFound();
            }

            _vendaRepository.Update(venda);
            await _vendaRepository.SaveChangesAsync();

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

            var venda = await _vendaRepository.GetByIdAsync(id);
            venda.CancelarVenda();
            await _vendaRepository.SaveChangesAsync();

            _vendaEventService.CompraCancelada(venda);

            return NoContent();
        }

        private async Task<bool> VendaExists(int id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            return venda != null;
        }




    }
}
