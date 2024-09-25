namespace Vendas.Domain.Entities
{
    public class Venda
    {
        private int _id;
        private string _numeroVenda;
        private DateTime _dataVenda;
        private int _clienteId;
        private string _nomeCliente;

        private List<ItemVenda> _itensVenda;
        private bool _isCancelado = false;

        public Venda(int id, string numeroVenda, DateTime dataVenda, int clienteId, string nomeCliente)
        {
            _id = id;
            _numeroVenda = numeroVenda;
            _dataVenda = dataVenda;
            _clienteId = clienteId;
            _nomeCliente = nomeCliente;
            _itensVenda = new List<ItemVenda>();
        }

        public int ObterId() => _id;
        public string ObterNumeroVenda() => _numeroVenda;
        public DateTime ObterDataVenda() => _dataVenda;
        public int ObterClienteId() => _clienteId;
        public string ObterNomeCliente() => _nomeCliente;

        public List<ItemVenda> ItensVenda => _itensVenda;

        public bool RemoverItem(ItemVenda item) => _isCancelado
          ? throw new InvalidOperationException("Não é possível remover itens de uma venda cancelada.")
          : _itensVenda.Remove(item);

        public bool CancelarVenda() => _isCancelado
            ? throw new InvalidOperationException("A venda já foi cancelada.")
            : _isCancelado = true;

        public void AdicionarItem(ItemVenda item)
        {
            if (_isCancelado)
                throw new InvalidOperationException("Não é possível adicionar itens a uma venda cancelada.");

            _itensVenda.Add(item);
        }

        public void AlterarCliente(int clienteId, string nomeCliente)
        {
            if (string.IsNullOrWhiteSpace(nomeCliente))
                throw new ArgumentNullException(nameof(nomeCliente));

            _clienteId = clienteId;
            _nomeCliente = nomeCliente;
        }
    }
}
