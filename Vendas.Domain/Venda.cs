namespace Vendas.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime Data { get; set; }
        public bool IsCancelado { get; set; }

        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }

        // Lista de itens
        public List<ItemVenda> ItensVenda { get; set; }

        public decimal ValorTotal
        {
            get
            {
                return ItensVenda.Sum(i => i.ValorTotal);
            }
        }

    }
}
