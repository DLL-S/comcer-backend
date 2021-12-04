using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade
{
	internal class TokenMap : IEntityTypeConfiguration<IdentityUserToken<int>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
		{
			builder.ToTable("IDT_TOKENS");

			builder.Property(x => x.UserId)
				.HasColumnName("IDUSUARIO");

			builder.Property(x => x.Name)
				.HasColumnName("NOME");

			builder.Property(x => x.Value)
				.HasColumnName("VALOR");

			builder.Property(x => x.LoginProvider)
				.HasColumnName("LOGINPROVIDER");
		}
	}
}
