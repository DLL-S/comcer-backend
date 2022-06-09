using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
    public partial class AtualizaPedidosComandaView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidosComandaView",
                columns: table => new
                {
                    IdComanda = table.Column<int>(type: "integer", nullable: false),
                    NomeComanda = table.Column<string>(type: "text", nullable: true),
                    ValorTotalComanda = table.Column<decimal>(type: "numeric", nullable: false),
                    StatusComanda = table.Column<string>(type: "text", nullable: false),
                    IdDoProdutoDoPedido = table.Column<int>(type: "integer", nullable: false),
                    NomeProdutoDoPedido = table.Column<string>(type: "text", nullable: true),
                    DescricaoProdutoDoPedido = table.Column<string>(type: "text", nullable: true),
                    PrecoProdutoDoPedido = table.Column<decimal>(type: "numeric", nullable: false),
                    FotoProdutoDoPedido = table.Column<string>(type: "text", nullable: true),
                    QuantidadeProdutoDoPedido = table.Column<int>(type: "integer", nullable: false),
                    StatusProdutoDoPedido = table.Column<string>(type: "text", nullable: false),
                    DataHoraPedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PedidosDoProdutoView",
                columns: table => new
                {
                    NumeroMesa = table.Column<int>(type: "integer", nullable: false),
                    NumeroPedido = table.Column<int>(type: "integer", nullable: false),
                    IdProdutoPedido = table.Column<int>(type: "integer", nullable: false),
                    ProdutoPedido = table.Column<string>(type: "text", nullable: true),
                    DataHoraPedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StatusPedido = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PedidosView",
                columns: table => new
                {
                    NumeroMesa = table.Column<int>(type: "integer", nullable: false),
                    NumeroPedido = table.Column<int>(type: "integer", nullable: false),
                    StatusPedido = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosComandaView");

            migrationBuilder.DropTable(
                name: "PedidosDoProdutoView");

            migrationBuilder.DropTable(
                name: "PedidosView");
        }
    }
}
