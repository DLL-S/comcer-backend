using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos
{
	public class PedidoProdutoMap : IEntityTypeConfiguration<ProdutoDoPedido>
	{
		private const string NOME_TABELA = "PEDIDOSDOPRODUTO";

		public void Configure(EntityTypeBuilder<ProdutoDoPedido> builder)
		{
			builder.ToTable(NOME_TABELA);
			builder.HasKey(x => x.Id);
			#region ID

			builder.Property(x => x.Id)
				 .HasColumnName("ID");

			builder.HasIndex(x => x.Id)
				 .HasDatabaseName("IDX_IDPEDIDOSPRODUTO")
				 .IsUnique();

			#endregion

			#region PRODUTO

			builder.Property(x => x.IdProduto)
				 .HasColumnName("IDPRODUTO")
				 .HasColumnType("NUMERIC")
				 .IsRequired();

			#endregion

			#region VALOR_UNITARIO

			builder.Property(x => x.ValorUnitario)
				 .HasColumnName("VALOR_UNITARIO")
				 .HasColumnType("NUMERIC")
				 .IsRequired();

			#endregion

			#region STATUS

			builder.Property(x => x.Status)
				 .HasColumnName("STATUS")
				 .HasConversion<string>()
				 .IsRequired();

			#endregion

			#region QUANTIDADE

			builder.Property(x => x.Quantidade)
				 .HasColumnName("QUANTIDADE")
				 .HasColumnType("NUMERIC")
				 .IsRequired();

			#endregion

			#region DataHora

			builder.Property(x => x.DataHoraPedido)
				 .HasColumnName("DATAHORAPEDIDO")
				 .HasColumnType("DATE")
				 .IsRequired();

			#endregion
		}
	}
}
