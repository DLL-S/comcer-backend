using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade
{
	internal class UsuarioLoginMap : IEntityTypeConfiguration<IdentityUserLogin<int>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> builder)
		{
			builder.ToTable("IDT_USUARIOLOGINS");

			builder.Property(x => x.UserId)
				.HasColumnName("IDUSUARIO");

			builder.Property(x => x.ProviderKey)
				.HasColumnName("CHAVEDOPROVEDOR");

			builder.Property(x => x.LoginProvider)
				.HasColumnName("LOGINPROVIDER");

			builder.Property(x => x.ProviderDisplayName)
				.HasColumnName("NOMEDEEXIBICAODOPROVIDER");
		}
	}
}
