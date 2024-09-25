namespace Vendas.Domain.Entities
{
    public class Venda
    {
        public int Id { get; private set; }
        public string NumeroVenda { get; private set; }
        public DateTime DataVenda { get; private set; }
        public int ClienteId { get; private set; }
        public string NomeCliente { get; private set; }

        public List<ItemVenda> ItensVenda { get; private set; } = new List<ItemVenda>();

        private bool _isCancelado = false;

        public Venda(string numeroVenda, DateTime dataVenda, int clienteId, string nomeCliente)
        {
            NumeroVenda = numeroVenda ?? throw new ArgumentNullException(nameof(numeroVenda));
            DataVenda = dataVenda;
            ClienteId = clienteId;
            NomeCliente = nomeCliente ?? throw new ArgumentNullException(nameof(nomeCliente));
        }

        public Venda(int id, string numeroVenda, DateTime dataVenda, int clienteId, string nomeCliente)
            : this(numeroVenda, dataVenda, clienteId, nomeCliente)
        {
            Id = id;
        }

        public bool RemoverItem(ItemVenda item)
        {
            if (_isCancelado)
                throw new InvalidOperationException("Não é possível remover itens de uma venda cancelada.");

            return ItensVenda.Remove(item);
        }

        public void AdicionarItem(ItemVenda item)
        {
            if (_isCancelado)
                throw new InvalidOperationException("Não é possível adicionar itens a uma venda cancelada.");

            ItensVenda.Add(item);
        }

        public bool CancelarVenda()
        {
            if (_isCancelado)
                throw new InvalidOperationException("A venda já foi cancelada.");

            _isCancelado = true;
            return _isCancelado;
        }

        public void AlterarCliente(int clienteId, string nomeCliente)
        {
            if (string.IsNullOrWhiteSpace(nomeCliente))
                throw new ArgumentNullException(nameof(nomeCliente));

            ClienteId = clienteId;
            NomeCliente = nomeCliente;
        }
    }
}
