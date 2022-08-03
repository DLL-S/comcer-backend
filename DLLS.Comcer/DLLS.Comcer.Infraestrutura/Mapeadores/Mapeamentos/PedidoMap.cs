using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos
{
	internal class PedidoMap : IEntityTypeConfiguration<Pedido>
	{
		private const string NOME_TABELA = "PEDIDOS";

		public void Configure(EntityTypeBuilder<Pedido> builder)
		{
			builder.ToTable(NOME_TABELA);
			builder.HasKey(x => x.Id);

			#region ID

			builder.Property(x => x.Id)
				 .HasColumnName("ID");

			builder.HasIndex(x => x.Id)
				 .HasDatabaseName("IDX_IDPEDIDOS")
				 .IsUnique();

			#endregion


			#region PRODUTOSPEDIDO

			builder.HasMany(x => x.ProdutosDoPedido)
				.WithOne()
				.HasForeignKey("PEDIDO")
				.OnDelete(DeleteBehavior.Cascade);

			builder.Navigation(x => x.ProdutosDoPedido)
				.AutoInclude();

			#endregion

			#region Observacao

			builder.Property(x => x.Observacao)
				 .HasColumnName("OBSERVACAO")
				 .HasColumnType("TEXT");

			#endregion

			#region DataHora

			builder.Property(x => x.DataHoraPedido)
				 .HasColumnName("DATAHORAPEDIDO")
				 .HasColumnType("TIMESTAMP")
				 .IsRequired();

			#endregion
		}
	}
}
