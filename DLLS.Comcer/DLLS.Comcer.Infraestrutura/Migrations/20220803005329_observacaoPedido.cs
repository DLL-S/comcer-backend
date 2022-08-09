using Microsoft.EntityFrameworkCore.Migrations;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
    public partial class observacaoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OBSERVACAO",
                table: "PEDIDOS",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OBSERVACAO",
                table: "PEDIDOS");
        }
    }
}
