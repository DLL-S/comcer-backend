using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos
{
	internal class ComandaMap : IEntityTypeConfiguration<Comanda>
	{
		private const string NOME_TABELA = "COMANDAS";

		public void Configure(EntityTypeBuilder<Comanda> builder)
		{
			builder.ToTable(NOME_TABELA);
			builder.HasKey(x => x.Id);

			#region ID

			builder.Property(x => x.Id)
				 .HasColumnName("ID");

			builder.HasIndex(x => x.Id)
				 .HasDatabaseName("IDX_IDCOMANDA")
				 .IsUnique();

			#endregion

			#region NOME

			builder.Property(x => x.Nome)
				 .HasColumnName("NOME")
				 .HasColumnType("TEXT")
				 .HasMaxLength(Comanda.TAMANHO_MAXIMO_NOME)
				 .IsRequired();

			#endregion

			#region VALOR

			builder.Property(x => x.Valor)
				 .HasColumnName("VALOR")
				 .HasColumnType("NUMERIC")
				 .IsRequired();

			#endregion

			#region PEDIDOS

			builder.HasMany(x => x.ListaPedidos)
				.WithOne()
				.HasForeignKey("COMANDA")
				.OnDelete(DeleteBehavior.Cascade);

			builder.Navigation(x => x.ListaPedidos)
				.AutoInclude();

			#endregion

			#region STATUS

			builder.Property(x => x.Status)
				 .HasColumnName("STATUS")
				 .HasConversion<string>()
				 .IsRequired();

			#endregion
		}
	}
}
