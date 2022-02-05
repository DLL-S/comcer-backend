using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade
{
	internal class ClaimsMap : IEntityTypeConfiguration<IdentityUserClaim<int>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder)
		{
			builder.ToTable("IDT_CLAIMS");

			builder.Property(x => x.Id)
				.HasColumnName("ID");

			builder.Property(x => x.UserId)
				.HasColumnName("IDUSUARIO");

			builder.Property(x => x.ClaimType)
				.HasColumnName("TIPO");

			builder.Property(x => x.ClaimValue)
				.HasColumnName("VALOR");
		}
	}
}
