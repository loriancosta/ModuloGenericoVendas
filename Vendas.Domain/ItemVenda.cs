namespace Vendas.Domain.Entities
{
    public class ItemVenda
    {
        private int _id;
        private int _vendaId;
        private int _produtoId;
        private string _nomeProduto;
        private decimal _quantidade;
        private decimal _precoUnitario;
        private decimal _desconto;

        public decimal ValorTotal => (_precoUnitario * _quantidade) - _desconto;

        public ItemVenda(int id, int produtoId, string nomeProduto, decimal quantidade, decimal precoUnitario, decimal desconto, int vendaId)
        {
            _id = id;
            _produtoId = produtoId;
            _nomeProduto = nomeProduto ?? throw new ArgumentNullException(nameof(nomeProduto));
            _quantidade = quantidade > 0 ? quantidade : throw new ArgumentException("A quantidade deve ser maior que zero.");
            _precoUnitario = precoUnitario > 0 ? precoUnitario : throw new ArgumentException("O preço unitário deve ser maior que zero.");
            _desconto = desconto >= 0 ? desconto : throw new ArgumentException("O desconto não pode ser negativo.");
            _vendaId = vendaId;
        }

        public int ObterVendaId()
        {
            return _vendaId;
        }

        public int ObterId() => _id;
        public int ObterProdutoId() => _produtoId;
        public string ObterNomeProduto() => _nomeProduto;
        public decimal ObterQuantidade() => _quantidade;
        public decimal ObterPrecoUnitario() => _precoUnitario;
        public decimal ObterDesconto() => _desconto;

        public void AlterarQuantidade(decimal novaQuantidade) => _quantidade = novaQuantidade > 0 
            ? novaQuantidade 
            : throw new ArgumentException("A quantidade deve ser maior que zero.");
        
        public void AlterarPrecoUnitario(decimal novoPreco) => _precoUnitario = novoPreco > 0 
            ? novoPreco 
            : throw new ArgumentException("O preço unitário deve ser maior que zero.");

        public void AplicarDesconto(decimal desconto) => _desconto = desconto >= 0 
            ? desconto 
            : throw new ArgumentException("O desconto não pode ser negativo.");
    }


}

