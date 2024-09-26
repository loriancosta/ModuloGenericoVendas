namespace Vendas.Domain.Entities
{
    public class ItemVenda
    {
        public int Id { get; private set; }
        public int VendaId { get; private set; }
        public int ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Desconto { get; private set; }

        public decimal ValorTotal => (PrecoUnitario * Quantidade) - Desconto;

        public Venda Venda { get; private set; }

        public Produto Produto { get; private set; }

        public ItemVenda(int produtoId, decimal quantidade, decimal precoUnitario, decimal desconto, int vendaId)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade > 0 ? quantidade : throw new ArgumentException("A quantidade deve ser maior que zero.");
            PrecoUnitario = precoUnitario > 0 ? precoUnitario : throw new ArgumentException("O preço unitário deve ser maior que zero.");
            Desconto = desconto >= 0 ? desconto : throw new ArgumentException("O desconto não pode ser negativo.");
            VendaId = vendaId;
        }

        public ItemVenda(int id, int produtoId, decimal quantidade, decimal precoUnitario, decimal desconto, int vendaId)
            : this(produtoId, quantidade, precoUnitario, desconto, vendaId)
        {
            Id = id;
        }

        public void AlterarQuantidade(decimal novaQuantidade)
        {
            Quantidade = novaQuantidade > 0 ? novaQuantidade : throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        public void AlterarPrecoUnitario(decimal novoPreco)
        {
            PrecoUnitario = novoPreco > 0 ? novoPreco : throw new ArgumentException("O preço unitário deve ser maior que zero.");
        }

        public void AplicarDesconto(decimal desconto)
        {
            Desconto = desconto >= 0 ? desconto : throw new ArgumentException("O desconto não pode ser negativo.");
        }
    }
}
