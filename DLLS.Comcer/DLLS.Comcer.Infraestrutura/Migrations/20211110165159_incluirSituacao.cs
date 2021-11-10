using Microsoft.EntityFrameworkCore.Migrations;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
    public partial class incluirSituacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Situacao",
                table: "Funcionarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Funcionarios");
        }
    }
}
