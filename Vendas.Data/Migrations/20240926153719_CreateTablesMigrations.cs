using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vendas.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablesMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVenda = table.Column<string>(maxLength: 100, nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    NomeCliente = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Produto",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.Sql(@"
            INSERT INTO Produtos 
                    (Descricao, Quantidade, PrecoUnitario) VALUES 
                    ('Fone de Ouvido Bluetooth', 50, 199.99),
                    ('Carregador Portátil 10000mAh', 30, 149.90),
                    ('Mouse Ergonômico Sem Fio', 20, 89.99),
                    ('Teclado Mecânico RGB', 15, 299.99),
                    ('Câmera de Segurança Wi-Fi', 10, 349.90),
                    ('Smartwatch Fitness', 25, 399.99),
                    ('Cabo USB-C 2 metros', 100, 29.99),
                    ('Adaptador HDMI para USB-C', 40, 59.90),
                    ('Monitor LED Full HD 24', 8, 849.90),
                    ('Webcam Full HD 1080p', 20, 199.90),
                    ('SSD Externo 1TB', 15, 499.99),
                    ('Hub USB 3.0 com 4 Portas', 50, 99.90),
                    ('Carregador Rápido USB-C 20W', 60, 69.90),
                    ('Smart Speaker com Assistente Virtual', 30, 229.99),
                    ('Power Bank Solar', 25, 159.99),
                    ('Drone com Câmera HD', 5, 1299.99),
                    ('Ring Light com Tripé', 40, 149.90),
                    ('Headset Gamer com Microfone', 35, 279.90),
                    ('Leitor de Cartão de Memória', 50, 49.99),
                    ('Caixa de Som Bluetooth', 20, 199.99);");


        }
    }
}
