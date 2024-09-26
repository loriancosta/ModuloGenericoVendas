namespace Vendas.Domain.Entities
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }



        public decimal ValorTotal => (PrecoUnitario * Quantidade) - Desconto;

        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
 
    }
}
