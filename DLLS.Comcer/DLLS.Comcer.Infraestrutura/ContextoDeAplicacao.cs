using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos;
using DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura
{
	/// <summary>
	/// Contexto padrão da aplicação.
	/// </summary>
	public class ContextoDeAplicacao : IdentityDbContext<Usuario, Role, int>
	{
		/// <summary>
		/// Inicia uma nova instância do contexto.
		/// </summary>
		/// <param name="opcoes"></param>
		public ContextoDeAplicacao(DbContextOptions<ContextoDeAplicacao> opcoes) : base(opcoes)
		{
		}

		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<Comanda> Comandas { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }

		/// <summary>
		/// Define os mapeamentos a serem aplicados durante a criação do modelo para o contexto.
		/// </summary>
		/// <param name="builder"></param>
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
			builder.ApplyConfiguration(new ProdutoMap());
			builder.ApplyConfiguration(new EnderecoMap());
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
