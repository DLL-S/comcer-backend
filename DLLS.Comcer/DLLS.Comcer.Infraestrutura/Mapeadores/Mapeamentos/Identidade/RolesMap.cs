using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade
{
	internal class RolesMap : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.ToTable("IDT_ROLES");

			builder.Property(x => x.Id)
				.HasColumnName("ID");

			builder.Property(x => x.Name)
				.HasColumnName("DESCRICAO");

			builder.Property(x => x.NormalizedName)
				.HasColumnName("DESCRICAO_NORMALIZADA");

			builder.Property(x => x.ConcurrencyStamp).
				HasColumnName("CONCURRENCYSTAMP");
		}
	}
}
