namespace Vendas.Domain.Entities
{
    public class ItemVenda
    {
        public int Id { get; set; }

        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }

        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }

        public decimal ValorTotal
        {
            get
            {
                return (PrecoUnitario * Quantidade) - Desconto;
            }
        }

        public int VendaId { get; set; }
    }
}

