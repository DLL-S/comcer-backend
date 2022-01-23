using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
	public partial class InclusaoCore : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "COMANDAS",
				columns: table => new {
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Nome = table.Column<string>(type: "text", nullable: true),
					Valor = table.Column<decimal>(type: "numeric", nullable: false),
					Status = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_COMANDAS", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "PRODUTOS",
				columns: table => new {
					ID = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					NOME = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
					DESCRICAO = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
					PRECO = table.Column<decimal>(type: "NUMERIC", nullable: false),
					FOTO = table.Column<string>(type: "TEXT", maxLength: 1024000, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PRODUTOS", x => x.ID);
				});

			migrationBuilder.CreateTable(
				name: "PEDIDOS",
				columns: table => new {
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					ProdutoId = table.Column<int>(type: "integer", nullable: true),
					Quantidade = table.Column<int>(type: "integer", nullable: false),
					ValorUnitario = table.Column<decimal>(type: "numeric", nullable: false),
					Status = table.Column<int>(type: "integer", nullable: false),
					ComandaId = table.Column<int>(type: "integer", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PEDIDOS", x => x.Id);
					table.ForeignKey(
						name: "FK_PEDIDOS_COMANDAS_ComandaId",
						column: x => x.ComandaId,
						principalTable: "COMANDAS",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_PEDIDOS_PRODUTOS_ProdutoId",
						column: x => x.ProdutoId,
						principalTable: "PRODUTOS",
						principalColumn: "ID",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_PEDIDOS_ComandaId",
				table: "PEDIDOS",
				column: "ComandaId");

			migrationBuilder.CreateIndex(
				name: "IX_PEDIDOS_ProdutoId",
				table: "PEDIDOS",
				column: "ProdutoId");

			migrationBuilder.CreateIndex(
				name: "IDX_IDPRODUTO",
				table: "PRODUTOS",
				column: "ID",
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PEDIDOS");

			migrationBuilder.DropTable(
				name: "COMANDAS");

			migrationBuilder.DropTable(
				name: "PRODUTOS");
		}
	}
}
