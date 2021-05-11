using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class EuSouBUrroEnaoFuiaEscola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EderecoCompleto",
                table: "Pedidos",
                newName: "EnderecoCompleto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnderecoCompleto",
                table: "Pedidos",
                newName: "EderecoCompleto");
        }
    }
}
