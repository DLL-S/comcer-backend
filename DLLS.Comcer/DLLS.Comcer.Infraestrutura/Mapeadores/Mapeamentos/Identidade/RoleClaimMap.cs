using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade
{
	internal class RoleClaimMap : IEntityTypeConfiguration<IdentityRoleClaim<int>>
	{
		public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> builder)
		{
			builder.ToTable("IDT_ROLECLAIMS");

			builder.Property(x => x.Id)
				.HasColumnName("ID");

			builder.Property(x => x.RoleId)
				.HasColumnName("IDROLE");

			builder.Property(x => x.ClaimType)
				.HasColumnName("TIPOCLAIM");

			builder.Property(x => x.ClaimValue)
				.HasColumnName("VALORCLAIM");
		}
	}
}
