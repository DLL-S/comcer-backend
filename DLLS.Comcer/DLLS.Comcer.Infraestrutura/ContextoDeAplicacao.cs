using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Dominio.Objetos.UsuarioObj;
using DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos;
using DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura
{
	public class ContextoDeAplicacao : IdentityDbContext<Usuario, IdentityRole<int>, int>
	{
		public ContextoDeAplicacao(DbContextOptions<ContextoDeAplicacao> opcoes) : base(opcoes)
		{
		}

		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			AddConfiguracoesDoIdentity(builder);
			AddConfiguracoesDoDominio(builder);
		}

		private static void AddConfiguracoesDoDominio(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new EnderecoMap());
			builder.ApplyConfiguration(new FuncionarioMap());
		}

		private void AddConfiguracoesDoIdentity(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new UsuarioMap());
			builder.ApplyConfiguration(new RolesMap());
			builder.ApplyConfiguration(new ClaimsMap());
			builder.ApplyConfiguration(new TokenMap());
			builder.ApplyConfiguration(new UsuarioLoginMap());
			builder.ApplyConfiguration(new RoleClaimMap());
			builder.ApplyConfiguration(new UsuarioRoleMap());
		}
	}
}
