using Vendas.Domain.Entities;

namespace Vendas.Application.Dtos
{
    public class VendaDto
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public List<ItemVendaDto> ItensVenda { get; set; } = new List<ItemVendaDto>();

    }
}
