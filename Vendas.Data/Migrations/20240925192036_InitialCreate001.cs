using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vendas.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_Vendas_VendaId",
                table: "ItensVenda");

            migrationBuilder.DropColumn(
                name: "Cancelada",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "ItensVenda");

            migrationBuilder.RenameColumn(
                name: "Filial",
                table: "Vendas",
                newName: "NomeCliente");

            migrationBuilder.RenameColumn(
                name: "ValorUnitario",
                table: "ItensVenda",
                newName: "PrecoUnitario");

            migrationBuilder.RenameColumn(
                name: "Produto",
                table: "ItensVenda",
                newName: "NomeProduto");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantidade",
                table: "ItensVenda",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ItensVenda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Venda",
                table: "ItensVenda",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Venda",
                table: "ItensVenda");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ItensVenda");

            migrationBuilder.RenameColumn(
                name: "NomeCliente",
                table: "Vendas",
                newName: "Filial");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "ItensVenda",
                newName: "ValorUnitario");

            migrationBuilder.RenameColumn(
                name: "NomeProduto",
                table: "ItensVenda",
                newName: "Produto");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelada",
                table: "Vendas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Vendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Vendas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "ItensVenda",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "ItensVenda",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_Vendas_VendaId",
                table: "ItensVenda",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
