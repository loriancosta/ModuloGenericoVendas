namespace Vendas.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        // Construtor
        public Produto(string descricao, int quantidade, decimal precoUnitario)
        {
            Descricao = !string.IsNullOrWhiteSpace(descricao) ? descricao : throw new ArgumentNullException(nameof(descricao));
            Quantidade = quantidade >= 0 ? quantidade : throw new ArgumentException("A quantidade deve ser maior ou igual a zero.");
            PrecoUnitario = precoUnitario >= 0 ? precoUnitario : throw new ArgumentException("O preço unitário deve ser maior ou igual a zero.");
        }
    }
}
