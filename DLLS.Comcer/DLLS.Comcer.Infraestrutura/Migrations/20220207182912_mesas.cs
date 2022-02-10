using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
    public partial class mesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MESA",
                table: "COMANDAS",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MESAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NUMERO = table.Column<int>(type: "INTEGER", nullable: false),
                    DISPONIVEL = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MESAS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMANDAS_MESA",
                table: "COMANDAS",
                column: "MESA");

            migrationBuilder.CreateIndex(
                name: "IDX_IDMESA",
                table: "MESAS",
                column: "ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_COMANDAS_MESAS_MESA",
                table: "COMANDAS",
                column: "MESA",
                principalTable: "MESAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMANDAS_MESAS_MESA",
                table: "COMANDAS");

            migrationBuilder.DropTable(
                name: "MESAS");

            migrationBuilder.DropIndex(
                name: "IX_COMANDAS_MESA",
                table: "COMANDAS");

            migrationBuilder.DropColumn(
                name: "MESA",
                table: "COMANDAS");
        }
    }
}
