using Microsoft.EntityFrameworkCore.Migrations;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
    public partial class correcaoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDOS_Comandas_ComandaId",
                table: "PEDIDOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDOS_PRODUTOS_ProdutoId",
                table: "PEDIDOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PEDIDOS",
                table: "PEDIDOS");

            migrationBuilder.RenameTable(
                name: "PEDIDOS",
                newName: "Pedidos");

            migrationBuilder.RenameIndex(
                name: "IX_PEDIDOS_ProdutoId",
                table: "Pedidos",
                newName: "IX_Pedidos_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_PEDIDOS_ComandaId",
                table: "Pedidos",
                newName: "IX_Pedidos_ComandaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Comandas_ComandaId",
                table: "Pedidos",
                column: "ComandaId",
                principalTable: "Comandas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_PRODUTOS_ProdutoId",
                table: "Pedidos",
                column: "ProdutoId",
                principalTable: "PRODUTOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Comandas_ComandaId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_PRODUTOS_ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "PEDIDOS");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ProdutoId",
                table: "PEDIDOS",
                newName: "IX_PEDIDOS_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ComandaId",
                table: "PEDIDOS",
                newName: "IX_PEDIDOS_ComandaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PEDIDOS",
                table: "PEDIDOS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDOS_Comandas_ComandaId",
                table: "PEDIDOS",
                column: "ComandaId",
                principalTable: "Comandas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDOS_PRODUTOS_ProdutoId",
                table: "PEDIDOS",
                column: "ProdutoId",
                principalTable: "PRODUTOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
