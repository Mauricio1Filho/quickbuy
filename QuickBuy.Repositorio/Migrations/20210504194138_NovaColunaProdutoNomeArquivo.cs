using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class NovaColunaProdutoNomeArquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeArquivo",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "FormaPagamento",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeArquivo",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "FormaPagamento");
        }
    }
}
