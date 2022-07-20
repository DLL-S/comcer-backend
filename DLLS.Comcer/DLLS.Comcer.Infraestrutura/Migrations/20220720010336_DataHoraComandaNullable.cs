using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
	public partial class DataHoraComandaNullable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DATAHORAFECHADACOMANDA",
				table: "COMANDAS",
				type: "TIMESTAMP",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "TIMESTAMP");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DATAHORAABERTURACOMANDA",
				table: "COMANDAS",
				type: "TIMESTAMP",
				nullable: false,
				defaultValue: DateTime.Now);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DATAHORAFECHADACOMANDA",
				table: "COMANDAS",
				type: "TIMESTAMP",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
				oldClrType: typeof(DateTime),
				oldType: "TIMESTAMP",
				oldNullable: true);
		}
	}
}
