namespace Vendas.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public bool IsCancelado { get; set; }

        public List<ItemVenda> ItensVenda { get; set; } = new List<ItemVenda>();
        
        public Venda(string numeroVenda, DateTime dataVenda, int clienteId, string nomeCliente, bool isCancelado)
        {
            NumeroVenda = !string.IsNullOrWhiteSpace(numeroVenda) ? numeroVenda : throw new ArgumentNullException(nameof(numeroVenda));
            DataVenda = dataVenda;
            ClienteId = clienteId;
            NomeCliente = !string.IsNullOrWhiteSpace(nomeCliente) ? nomeCliente : throw new ArgumentNullException(nameof(nomeCliente));
            IsCancelado = isCancelado;
        }


    }
}
