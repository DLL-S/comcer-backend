using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos
{
	internal class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
	{
		private const string NOME_TABELA = "FUNCIONARIOS";

		public void Configure(EntityTypeBuilder<Funcionario> builder)
		{
			builder.ToTable(NOME_TABELA);
			builder.HasKey(x => x.Id);

			#region ID

			builder.Property(x => x.Id)
				 .HasColumnName("ID");

			builder.HasIndex(x => x.Id)
				 .HasDatabaseName("IDX_IDFUNCIONARIO")
				 .IsUnique();

			#endregion

			#region CELULAR

			builder.Property(x => x.Celular)
				 .HasColumnName("CELULAR")
				 .HasMaxLength(Funcionario.TAMANHO_MAXIMO_CELULAR)
				 .HasColumnType("TEXT");

			#endregion

			#region CPF

			builder.Property(x => x.CPF)
				 .HasColumnName("CPF")
				 .HasColumnType("TEXT")
				 .HasMaxLength(Funcionario.TAMANHO_MAXIMO_CPF)
				 .IsRequired();

			#endregion

			#region DATA_NASCIMENTO

			builder.Property(x => x.DataNascimento)
				 .HasColumnName("DATA_NASCIMENTO")
				 .HasColumnType("DATE")
				 .IsRequired();

			#endregion

			#region EMAIL

			builder.Property(x => x.Email)
				 .HasColumnName("EMAIL")
				 .HasColumnType("TEXT")
				 .HasMaxLength(Funcionario.TAMANHO_MAXIMO_EMAIL)
				 .IsRequired();

			builder.HasIndex(x => x.Email)
				 .HasDatabaseName("IDX_EMAILFUNCIONARIO")
				 .IsUnique();

			#endregion

			#region NOME

			builder.Property(x => x.Nome)
				 .HasColumnName("NOME")
				 .HasColumnType("TEXT")
				 .HasMaxLength(Funcionario.TAMANHO_MAXIMO_NOME)
				 .IsRequired();

			#endregion

			#region ENDERECO

			builder.HasOne(x => x.Endereco)
				.WithMany()
				.HasForeignKey("IDENDERECO")
				.OnDelete(DeleteBehavior.Cascade);

			#endregion

			#region SITUACAO

			builder.Property(x => x.Situacao)
				 .HasColumnName("SITUACAO")
				 .HasConversion<string>()
				 .IsRequired();

			#endregion
		}
	}
}
