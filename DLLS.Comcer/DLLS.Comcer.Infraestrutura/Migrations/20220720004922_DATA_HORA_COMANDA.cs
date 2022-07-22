using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
	public partial class DATA_HORA_COMANDA : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "DATAHORAABERTURACOMANDA",
				table: "COMANDAS",
				type: "TIMESTAMP",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<DateTime>(
				name: "DATAHORAFECHADACOMANDA",
				table: "COMANDAS",
				type: "TIMESTAMP",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "DATAHORAABERTURACOMANDA",
				table: "COMANDAS");

			migrationBuilder.DropColumn(
				name: "DATAHORAFECHADACOMANDA",
				table: "COMANDAS");
		}
	}
}
