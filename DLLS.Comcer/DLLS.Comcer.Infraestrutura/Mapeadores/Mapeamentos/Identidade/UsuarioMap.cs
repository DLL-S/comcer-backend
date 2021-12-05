using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade
{
	internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("IDT_USUARIOS");

			builder.Property(x => x.Id)
				.HasColumnName("ID");

			#region NOME DE USUARIO

			builder.Property(x => x.UserName)
				.HasColumnName("NOMEDEUSUARIO")
				.HasMaxLength(Funcionario.TAMANHO_MAXIMO_EMAIL);

			builder.Property(x => x.NormalizedUserName)
				.HasColumnName("NOMEDEUSUARIO_NORMALIZADO")
				.HasMaxLength(Funcionario.TAMANHO_MAXIMO_EMAIL);

			#endregion

			#region EMAIL

			builder.Property(x => x.Email)
				.HasMaxLength(Funcionario.TAMANHO_MAXIMO_EMAIL)
				.HasColumnName("EMAIL")
				.IsRequired();

			builder.Property(x => x.NormalizedEmail)
				.HasMaxLength(Funcionario.TAMANHO_MAXIMO_EMAIL)
				.HasColumnName("EMAIL_NORMALIZADO");

			builder.Property(x => x.EmailConfirmed)
				.HasColumnName("EMAILCONFIRMADO");

			builder.HasIndex(x => x.Email)
				 .HasDatabaseName("IDX_EMAILUSUARIO")
				 .IsUnique();

			#endregion

			#region SENHA

			builder.Property(x => x.PasswordHash)
				.HasColumnName("SENHA");

			builder.Property(x => x.SecurityStamp)
				.HasColumnName("CARIMBODESENHA");

			builder.Property(x => x.TwoFactorEnabled)
				.HasColumnName("DOISFATORES");

			#endregion

			#region FUNCIONARIO

			builder.HasOne(x => x.Funcionario)
				.WithMany()
				.HasForeignKey("IDFUNCIONARIO")
				.IsRequired();

			builder.Navigation(x => x.Funcionario)
				.AutoInclude();

			#endregion

			#region PROPRIEDADES DE CONFIGURACAO

			builder.Property(x => x.ConcurrencyStamp)
				.HasColumnName("CONCURRENCYSTAMP");

			builder.Property(x => x.LockoutEnabled)
				.HasColumnName("INATIVO");

			builder.Property(x => x.LockoutEnd)
				.HasColumnName("PRAZODEINATIVACAO");

			builder.Property(x => x.AccessFailedCount)
				.HasColumnName("LOGINSCOMFALHA");

			#endregion

			#region PROPRIEDADES IGNORADAS

			#region CELULAR

			builder.Ignore(x => x.PhoneNumber);
			builder.Ignore(x => x.PhoneNumberConfirmed);

			#endregion

			#endregion
		}
	}
}
