using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos
{
	internal class ProdutoMap : IEntityTypeConfiguration<Produto>
	{
		private const string NOME_TABELA = "PRODUTOS";

		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.ToTable(NOME_TABELA);
			builder.HasKey(x => x.Id);

			#region ID

			builder.Property(x => x.Id)
				 .HasColumnName("ID");

			builder.HasIndex(x => x.Id)
				 .HasDatabaseName("IDX_IDPRODUTO")
				 .IsUnique();

			#endregion

			#region NOME

			builder.Property(x => x.Nome)
				 .HasColumnName("NOME")
				 .HasColumnType("TEXT")
				 .HasMaxLength(Produto.TAMANHO_MAXIMO_NOME)
				 .IsRequired();

			#endregion

			#region PRECO

			builder.Property(x => x.Preco)
				 .HasColumnName("PRECO")
				 .HasColumnType("NUMERIC")
				 .IsRequired();

			#endregion

			#region DESCRICAO

			builder.Property(x => x.Descricao)
				 .HasColumnName("DESCRICAO")
				 .HasColumnType("TEXT")
				 .HasMaxLength(Produto.TAMANHO_MAXIMO_DESCRICAO);

			#endregion

			#region FOTO

			builder.Property(x => x.Foto)
				 .HasColumnName("FOTO")
				 .HasColumnType("TEXT")
				 .HasMaxLength(Produto.TAMANHO_MAXIMO_FOTO)
				 .IsRequired();

			#endregion
		}
	}
}
