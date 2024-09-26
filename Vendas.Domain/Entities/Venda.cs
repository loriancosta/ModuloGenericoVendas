namespace Vendas.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }

        public List<ItemVenda> ItensVenda { get; set; } = new List<ItemVenda>();
        private bool _isCancelado;

        public Venda(string numeroVenda, DateTime dataVenda, int clienteId, string nomeCliente)
        {
            NumeroVenda = !string.IsNullOrWhiteSpace(numeroVenda) ? numeroVenda : throw new ArgumentNullException(nameof(numeroVenda));
            DataVenda = dataVenda;
            ClienteId = clienteId;
            NomeCliente = !string.IsNullOrWhiteSpace(nomeCliente) ? nomeCliente : throw new ArgumentNullException(nameof(nomeCliente));
        }

        public bool CancelarVenda()
        {
            if (_isCancelado)
                throw new InvalidOperationException("A venda já foi cancelada.");

            _isCancelado = true;
            return _isCancelado;
        }

    }
}
