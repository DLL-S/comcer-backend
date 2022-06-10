using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
	public partial class DataHoraPedido : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DATAHORAPEDIDO",
				table: "PEDIDOSDOPRODUTO",
				type: "TIMESTAMP",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "DATE");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DATAHORAPEDIDO",
				table: "PEDIDOS",
				type: "TIMESTAMP",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "DATE");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DATAHORAPEDIDO",
				table: "PEDIDOSDOPRODUTO",
				type: "DATE",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "TIMESTAMP");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DATAHORAPEDIDO",
				table: "PEDIDOS",
				type: "DATE",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "TIMESTAMP");
		}
	}
}
