using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade
{
	internal class UsuarioRoleMap : IEntityTypeConfiguration<IdentityUserRole<int>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
		{
			builder.ToTable("IDT_USUARIOROLES");

			builder.Property(x => x.UserId)
				.HasColumnName("IDUSUARIO");

			builder.Property(x => x.RoleId)
				.HasColumnName("IDROLES");
		}
	}
}
