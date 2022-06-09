﻿// <auto-generated />
using System;
using DLLS.Comcer.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
    [DbContext(typeof(ContextoDeAplicacao))]
    partial class ContextoDeAplicacaoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.ComandaObj.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MESA")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT")
                        .HasColumnName("NOME");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("STATUS");

                    b.Property<decimal>("Valor")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("VALOR");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDCOMANDA");

                    b.HasIndex("MESA");

                    b.ToTable("COMANDAS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.Compartilhados.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT")
                        .HasColumnName("BAIRRO");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT")
                        .HasColumnName("CIDADE");

                    b.Property<string>("Complemento")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT")
                        .HasColumnName("COMPLEMENTO");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT")
                        .HasColumnName("ESTADO");

                    b.Property<int>("Numero")
                        .HasColumnType("INT")
                        .HasColumnName("NUMERO");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT")
                        .HasColumnName("RUA");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDENDERECO");

                    b.ToTable("ENDERECOS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.FuncionarioObj.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("TEXT")
                        .HasColumnName("CPF");

                    b.Property<string>("Celular")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT")
                        .HasColumnName("CELULAR");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT")
                        .HasColumnName("EMAIL");

                    b.Property<int?>("IDENDERECO")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT")
                        .HasColumnName("NOME");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("SITUACAO");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IDX_EMAILFUNCIONARIO");

                    b.HasIndex("IDENDERECO");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDFUNCIONARIO");

                    b.ToTable("FUNCIONARIOS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.IdentityObj.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("CONCURRENCYSTAMP");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("DESCRICAO_NORMALIZADA");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("IDT_ROLES");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.IdentityObj.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("LOGINSCOMFALHA");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("CONCURRENCYSTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("EMAIL");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("EMAILCONFIRMADO");

                    b.Property<int>("IDFUNCIONARIO")
                        .HasColumnType("integer");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("INATIVO");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("PRAZODEINATIVACAO");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("EMAIL_NORMALIZADO");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("NOMEDEUSUARIO_NORMALIZADO");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("SENHA");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("CARIMBODESENHA");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("DOISFATORES");

                    b.Property<string>("UserName")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("NOMEDEUSUARIO");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IDX_EMAILUSUARIO");

                    b.HasIndex("IDFUNCIONARIO");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("IDT_USUARIOS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.MesaObj.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Disponivel")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DISPONIVEL");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER")
                        .HasColumnName("NUMERO");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDMESA");

                    b.ToTable("MESAS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.PedidoObj.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("COMANDA")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataHoraPedido")
                        .HasColumnType("DATE")
                        .HasColumnName("DATAHORAPEDIDO");

                    b.HasKey("Id");

                    b.HasIndex("COMANDA");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDPEDIDOS");

                    b.ToTable("PEDIDOS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.PedidoObj.ProdutoDoPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataHoraPedido")
                        .HasColumnType("DATE")
                        .HasColumnName("DATAHORAPEDIDO");

                    b.Property<decimal>("IdProduto")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("IDPRODUTO");

                    b.Property<int?>("PEDIDO")
                        .HasColumnType("integer");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("QUANTIDADE");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("STATUS");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("VALOR_UNITARIO");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDPEDIDOSPRODUTO");

                    b.HasIndex("PEDIDO");

                    b.ToTable("PEDIDOSDOPRODUTO");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.ProdutoObj.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(1024000)
                        .HasColumnType("TEXT")
                        .HasColumnName("FOTO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT")
                        .HasColumnName("NOME");

                    b.Property<decimal>("Preco")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("PRECO");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDPRODUTO");

                    b.ToTable("PRODUTOS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Views.PedidosComandaView", b =>
                {
                    b.Property<DateTime>("DataHoraPedido")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DescricaoProdutoDoPedido")
                        .HasColumnType("text");

                    b.Property<string>("FotoProdutoDoPedido")
                        .HasColumnType("text");

                    b.Property<int>("IdComanda")
                        .HasColumnType("integer");

                    b.Property<int>("IdDoProdutoDoPedido")
                        .HasColumnType("integer");

                    b.Property<string>("NomeComanda")
                        .HasColumnType("text");

                    b.Property<string>("NomeProdutoDoPedido")
                        .HasColumnType("text");

                    b.Property<decimal>("PrecoProdutoDoPedido")
                        .HasColumnType("numeric");

                    b.Property<int>("QuantidadeProdutoDoPedido")
                        .HasColumnType("integer");

                    b.Property<string>("StatusComanda")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusProdutoDoPedido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorTotalComanda")
                        .HasColumnType("numeric");

                    b.ToTable("PedidosComandaView");

                    b
                        .HasAnnotation("Relational:SqlQuery", "select  c.\"ID\" as idComanda, c.\"NOME\" as nomeComanda, c.\"VALOR\" as valorTotalComanda, c.\"STATUS\" statusComanda, pp.\"ID\" idDoProdutoDoPedido, prod.\"NOME\" as nomeProdutoDoPedido, prod.\"DESCRICAO\" as descricaoProdutoDoPedido, prod.\"PRECO\" precoProdutoDoPedido, prod.\"FOTO\" as fotoProdutoDoPedido, pp.\"QUANTIDADE\" as quantidadeProdutoDoPedido, pp.\"STATUS\" as statusProdutoDoPedido, pp.\"DATAHORAPEDIDO\" as dataHoraPedido from \"PEDIDOSDOPRODUTO\" pp inner join \"PEDIDOS\" p on p.\"ID\" = pp.\"PEDIDO\" inner join \"COMANDAS\" c on p.\"COMANDA\" = c.\"ID\" left join \"PRODUTOS\" prod  on prod.\"ID\" = pp.\"IDPRODUTO\" ");
                });

            modelBuilder.Entity("DLLS.Comcer.Interfaces.ModelosViews.PedidoProdutoView", b =>
                {
                    b.Property<DateTime>("DataHoraPedido")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdProdutoPedido")
                        .HasColumnType("integer");

                    b.Property<int>("NumeroMesa")
                        .HasColumnType("integer");

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("integer");

                    b.Property<string>("ProdutoPedido")
                        .HasColumnType("text");

                    b.Property<string>("StatusPedido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("PedidosDoProdutoView");

                    b
                        .HasAnnotation("Relational:SqlQuery", "select p.\"ID\" as NumeroPedido, coalesce(m.\"NUMERO\", 0) as NumeroMesa, pp.\"ID\" as IdProdutoPedido, prod.\"NOME\" as ProdutoPedido, pp.\"DATAHORAPEDIDO\" as DataHoraPedido, pp.\"STATUS\" as StatusPedido from \"PEDIDOS\" p inner join \"COMANDAS\" c  on p.\"COMANDA\" = c.\"ID\" left join \"MESAS\" m  on m.\"ID\" = c.\"MESA\" inner join \"PEDIDOSDOPRODUTO\" pp on pp.\"PEDIDO\" = p.\"ID\"  inner join \"PRODUTOS\" prod on prod.\"ID\" = pp.\"IDPRODUTO\" ");
                });

            modelBuilder.Entity("DLLS.Comcer.Interfaces.ModelosViews.PedidoView", b =>
                {
                    b.Property<int>("NumeroMesa")
                        .HasColumnType("integer");

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("integer");

                    b.Property<string>("StatusPedido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("PedidosView");

                    b
                        .HasAnnotation("Relational:SqlQuery", "select p.\"ID\" as NumeroPedido, m.\"NUMERO\" as NumeroMesa, case when(select count(*) from (select count(*) as contEntregue, (select count(*) from (select \"STATUS\" from \"PEDIDOSDOPRODUTO\" pp where \"PEDIDO\" = p.\"ID\" AND \"STATUS\" <> 'CANCELADO' group by \"STATUS\") listaTotal) as contTotal from (select \"STATUS\" from \"PEDIDOSDOPRODUTO\" pp where \"PEDIDO\" = p.\"ID\" AND \"STATUS\" <> 'CANCELADO' group by \"STATUS\") listaStatus where \"STATUS\" = 'ENTREGUE') Contaentregue where Contaentregue.contEntregue = Contaentregue.contTotal) = 1 then 'ENTREGUE' when(select count(*) from(select \"STATUS\" from \"PEDIDOSDOPRODUTO\" pp where \"PEDIDO\" = p.\"ID\" AND \"STATUS\" <> 'CANCELADO' group by \"STATUS\") listaStatus where \"STATUS\" <> 'ENTREGUE' and \"STATUS\" <> 'PRONTO') = 0 then 'PRONTO' else 'PENDENTE' end as StatusPedido from \"PEDIDOS\" p inner join \"COMANDAS\" c on p.\"COMANDA\" = c.\"ID\" inner join \"MESAS\" m  on m.\"ID\" = c.\"MESA\"");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("TIPOCLAIM");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("VALORCLAIM");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("IDROLE");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("IDT_ROLECLAIMS");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("TIPO");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("VALOR");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("IDUSUARIO");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IDT_CLAIMS");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("LOGINPROVIDER");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("CHAVEDOPROVEDOR");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("NOMEDEEXIBICAODOPROVIDER");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("IDUSUARIO");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("IDT_USUARIOLOGINS");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("IDUSUARIO");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("IDROLE");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("IDT_USUARIOROLES");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("IDUSUARIO");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("LOGINPROVIDER");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("NOME");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("VALOR");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("IDT_TOKENS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.ComandaObj.Comanda", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.MesaObj.Mesa", null)
                        .WithMany("Comandas")
                        .HasForeignKey("MESA")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.FuncionarioObj.Funcionario", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.Compartilhados.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IDENDERECO")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.IdentityObj.Usuario", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.FuncionarioObj.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("IDFUNCIONARIO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.PedidoObj.Pedido", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.ComandaObj.Comanda", null)
                        .WithMany("ListaPedidos")
                        .HasForeignKey("COMANDA")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.PedidoObj.ProdutoDoPedido", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.PedidoObj.Pedido", null)
                        .WithMany("ProdutosDoPedido")
                        .HasForeignKey("PEDIDO")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.IdentityObj.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.IdentityObj.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.IdentityObj.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.IdentityObj.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLLS.Comcer.Dominio.Objetos.IdentityObj.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.IdentityObj.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.ComandaObj.Comanda", b =>
                {
                    b.Navigation("ListaPedidos");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.MesaObj.Mesa", b =>
                {
                    b.Navigation("Comandas");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.PedidoObj.Pedido", b =>
                {
                    b.Navigation("ProdutosDoPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
