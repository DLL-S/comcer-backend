﻿// <auto-generated />
using System;
using DLLS.Comcer.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DLLS.Comcer.Infraestrutura.Migrations
{
    [DbContext(typeof(ContextoDeAplicacao))]
    [Migration("20211204231044_SetupComFuncionariosETabelasDoIdentity")]
    partial class SetupComFuncionariosETabelasDoIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.Compartilhados.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT")
                        .HasColumnName("BAIRRO");

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT")
                        .HasColumnName("CIDADE");

                    b.Property<string>("Complemento")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT")
                        .HasColumnName("COMPLEMENTO");

                    b.Property<string>("Estado")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT")
                        .HasColumnName("ESTADO");

                    b.Property<decimal>("Numero")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("NUMERO");

                    b.Property<string>("Rua")
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

                    b.Property<decimal>("Situacao")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("SITUACAO");

                    b.HasKey("Id");

                    b.HasIndex("IDENDERECO");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDFUNCIONARIO");

                    b.ToTable("FUNCIONARIOS");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.UsuarioObj.Usuario", b =>
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

                    b.HasIndex("IDFUNCIONARIO");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("IDT_USUARIOS");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
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
                        .HasColumnName("IDROLES");

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

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.FuncionarioObj.Funcionario", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.Compartilhados.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IDENDERECO")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("DLLS.Comcer.Dominio.Objetos.UsuarioObj.Usuario", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.FuncionarioObj.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("IDFUNCIONARIO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.UsuarioObj.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.UsuarioObj.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLLS.Comcer.Dominio.Objetos.UsuarioObj.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("DLLS.Comcer.Dominio.Objetos.UsuarioObj.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
