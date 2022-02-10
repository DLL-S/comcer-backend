using DLLS.Comcer.Dominio.Objetos.MesaObj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos
{
	internal class MesaMap : IEntityTypeConfiguration<Mesa>
	{
		private const string NOME_TABELA = "MESAS";

		public void Configure(EntityTypeBuilder<Mesa> builder)
		{
			builder.ToTable(NOME_TABELA);
			builder.HasKey(x => x.Id);

			#region ID

			builder.Property(x => x.Id)
				 .HasColumnName("ID");

			builder.HasIndex(x => x.Id)
				 .HasDatabaseName("IDX_IDMESA")
				 .IsUnique();

			#endregion

			#region NUMERO

			builder.Property(x => x.Numero)
				 .HasColumnName("NUMERO")
				 .HasColumnType("INTEGER")
				 //.HasMaxLength()
				 .IsRequired();

			#endregion

			#region DISPONIVEL

			builder.Property(x => x.Disponivel)
				 .HasColumnName("DISPONIVEL")
				 .HasColumnType("TEXT")
				 .IsRequired();

			#endregion

			#region PEDIDOS

			builder.HasMany(x => x.Comandas)
				.WithOne()
				.HasForeignKey("MESA")
				.OnDelete(DeleteBehavior.Cascade);

			builder.Navigation(x => x.Comandas)
				.AutoInclude();

			#endregion
		}
	}
}
