using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
    public partial class FKPedidosProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMANDAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    VALOR = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    STATUS = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMANDAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CEP = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    CIDADE = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ESTADO = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    BAIRRO = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    RUA = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    NUMERO = table.Column<int>(type: "INT", nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IDT_ROLES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRICAO = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    DESCRICAO_NORMALIZADA = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CONCURRENCYSTAMP = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDT_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
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
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DATAHORAPEDIDO = table.Column<DateTime>(type: "DATE", nullable: false),
                    COMANDA = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEDIDOS_COMANDAS_COMANDA",
                        column: x => x.COMANDA,
                        principalTable: "COMANDAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "DATE", nullable: false),
                    EMAIL = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CELULAR = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    IDENDERECO = table.Column<int>(type: "integer", nullable: true),
                    SITUACAO = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIOS_ENDERECOS_IDENDERECO",
                        column: x => x.IDENDERECO,
                        principalTable: "ENDERECOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDT_ROLECLAIMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDROLE = table.Column<int>(type: "integer", nullable: false),
                    TIPOCLAIM = table.Column<string>(type: "text", nullable: true),
                    VALORCLAIM = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDT_ROLECLAIMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IDT_ROLECLAIMS_IDT_ROLES_IDROLE",
                        column: x => x.IDROLE,
                        principalTable: "IDT_ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOSDOPRODUTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDPRODUTO = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    QUANTIDADE = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    VALOR_UNITARIO = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    STATUS = table.Column<string>(type: "text", nullable: false),
                    DATAHORAPEDIDO = table.Column<DateTime>(type: "DATE", nullable: false),
                    PEDIDO = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOSDOPRODUTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEDIDOSDOPRODUTO_PEDIDOS_PEDIDO",
                        column: x => x.PEDIDO,
                        principalTable: "PEDIDOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDT_USUARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDFUNCIONARIO = table.Column<int>(type: "integer", nullable: false),
                    NOMEDEUSUARIO = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    NOMEDEUSUARIO_NORMALIZADO = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    EMAIL = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    EMAIL_NORMALIZADO = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    EMAILCONFIRMADO = table.Column<bool>(type: "boolean", nullable: false),
                    SENHA = table.Column<string>(type: "text", nullable: true),
                    CARIMBODESENHA = table.Column<string>(type: "text", nullable: true),
                    CONCURRENCYSTAMP = table.Column<string>(type: "text", nullable: true),
                    DOISFATORES = table.Column<bool>(type: "boolean", nullable: false),
                    PRAZODEINATIVACAO = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    INATIVO = table.Column<bool>(type: "boolean", nullable: false),
                    LOGINSCOMFALHA = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDT_USUARIOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IDT_USUARIOS_FUNCIONARIOS_IDFUNCIONARIO",
                        column: x => x.IDFUNCIONARIO,
                        principalTable: "FUNCIONARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDT_CLAIMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDUSUARIO = table.Column<int>(type: "integer", nullable: false),
                    TIPO = table.Column<string>(type: "text", nullable: true),
                    VALOR = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDT_CLAIMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IDT_CLAIMS_IDT_USUARIOS_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "IDT_USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDT_TOKENS",
                columns: table => new
                {
                    IDUSUARIO = table.Column<int>(type: "integer", nullable: false),
                    LOGINPROVIDER = table.Column<string>(type: "text", nullable: false),
                    NOME = table.Column<string>(type: "text", nullable: false),
                    VALOR = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDT_TOKENS", x => new { x.IDUSUARIO, x.LOGINPROVIDER, x.NOME });
                    table.ForeignKey(
                        name: "FK_IDT_TOKENS_IDT_USUARIOS_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "IDT_USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDT_USUARIOLOGINS",
                columns: table => new
                {
                    LOGINPROVIDER = table.Column<string>(type: "text", nullable: false),
                    CHAVEDOPROVEDOR = table.Column<string>(type: "text", nullable: false),
                    NOMEDEEXIBICAODOPROVIDER = table.Column<string>(type: "text", nullable: true),
                    IDUSUARIO = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDT_USUARIOLOGINS", x => new { x.LOGINPROVIDER, x.CHAVEDOPROVEDOR });
                    table.ForeignKey(
                        name: "FK_IDT_USUARIOLOGINS_IDT_USUARIOS_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "IDT_USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDT_USUARIOROLES",
                columns: table => new
                {
                    IDUSUARIO = table.Column<int>(type: "integer", nullable: false),
                    IDROLE = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDT_USUARIOROLES", x => new { x.IDUSUARIO, x.IDROLE });
                    table.ForeignKey(
                        name: "FK_IDT_USUARIOROLES_IDT_ROLES_IDROLE",
                        column: x => x.IDROLE,
                        principalTable: "IDT_ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IDT_USUARIOROLES_IDT_USUARIOS_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "IDT_USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_IDCOMANDA",
                table: "COMANDAS",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_IDENDERECO",
                table: "ENDERECOS",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_EMAILFUNCIONARIO",
                table: "FUNCIONARIOS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_IDFUNCIONARIO",
                table: "FUNCIONARIOS",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIOS_IDENDERECO",
                table: "FUNCIONARIOS",
                column: "IDENDERECO");

            migrationBuilder.CreateIndex(
                name: "IX_IDT_CLAIMS_IDUSUARIO",
                table: "IDT_CLAIMS",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_IDT_ROLECLAIMS_IDROLE",
                table: "IDT_ROLECLAIMS",
                column: "IDROLE");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "IDT_ROLES",
                column: "DESCRICAO_NORMALIZADA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IDT_USUARIOLOGINS_IDUSUARIO",
                table: "IDT_USUARIOLOGINS",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_IDT_USUARIOROLES_IDROLE",
                table: "IDT_USUARIOROLES",
                column: "IDROLE");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "IDT_USUARIOS",
                column: "EMAIL_NORMALIZADO");

            migrationBuilder.CreateIndex(
                name: "IDX_EMAILUSUARIO",
                table: "IDT_USUARIOS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IDT_USUARIOS_IDFUNCIONARIO",
                table: "IDT_USUARIOS",
                column: "IDFUNCIONARIO");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "IDT_USUARIOS",
                column: "NOMEDEUSUARIO_NORMALIZADO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_IDPEDIDOS",
                table: "PEDIDOS",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_COMANDA",
                table: "PEDIDOS",
                column: "COMANDA");

            migrationBuilder.CreateIndex(
                name: "IDX_IDPEDIDOSPRODUTO",
                table: "PEDIDOSDOPRODUTO",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOSDOPRODUTO_PEDIDO",
                table: "PEDIDOSDOPRODUTO",
                column: "PEDIDO");

            migrationBuilder.CreateIndex(
                name: "IDX_IDPRODUTO",
                table: "PRODUTOS",
                column: "ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IDT_CLAIMS");

            migrationBuilder.DropTable(
                name: "IDT_ROLECLAIMS");

            migrationBuilder.DropTable(
                name: "IDT_TOKENS");

            migrationBuilder.DropTable(
                name: "IDT_USUARIOLOGINS");

            migrationBuilder.DropTable(
                name: "IDT_USUARIOROLES");

            migrationBuilder.DropTable(
                name: "PEDIDOSDOPRODUTO");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "IDT_ROLES");

            migrationBuilder.DropTable(
                name: "IDT_USUARIOS");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "FUNCIONARIOS");

            migrationBuilder.DropTable(
                name: "COMANDAS");

            migrationBuilder.DropTable(
                name: "ENDERECOS");
        }
    }
}
