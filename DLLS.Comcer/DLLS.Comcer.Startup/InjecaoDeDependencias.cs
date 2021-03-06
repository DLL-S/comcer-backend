using System;
using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using DLLS.Comcer.Infraestrutura;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Negocio.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLLS.Comcer.Startup
{
	/// <summary>
	/// Classe para configuração de resolução de dependências da aplicação.
	/// </summary>
	public static class InjecaoDeDependencias
	{
		/// <summary>
		/// Método de extensão para adicionar resolução automática de serviços,
		/// repositórios, conversores e contextos de banco de dados.
		/// </summary>
		/// <param name="servicos">A coleção de serviços da aplicação.</param>
		/// <param name="configuracao">Parâmetros de configuração da aplicação.</param>
		public static void AddResolucaoDeDependencias(this IServiceCollection servicos)
		{
			AddResolucaoDeBancoDeDados(servicos);
			AddResolucaoDeAddResolucaoDeIdentidade(servicos);
			AddResolucaoDeServicos(servicos);
		}

		/// <summary>
		/// Método de extensão para adicionar resolução automática de serviços,
		/// repositórios, conversores e contextos de banco de dados.
		/// </summary>
		public static void ExecuteMigrationsScoped(this IApplicationBuilder app)
		{
			using IServiceScope scope = app.ApplicationServices.CreateScope();
			ContextoDeAplicacao db = scope.ServiceProvider.GetRequiredService<ContextoDeAplicacao>();
			db.Database.Migrate();
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		/// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
		private static void AddResolucaoDeBancoDeDados(IServiceCollection servicos)
		{
			servicos.AddDbContext<ContextoDeAplicacao>(options =>
				options.UseNpgsql(ConnectionStringUtils.ObtenhaStringDeConexao()));

			servicos.AddTransient<IRepositorioFuncionario, RepositorioFuncionario>();
			servicos.AddTransient<IRepositorioComanda, RepositorioComanda>();
			servicos.AddTransient<IRepositorioPedido, RepositorioPedido>();
			servicos.AddTransient<IRepositorioProduto, RepositorioProduto>();
			servicos.AddTransient<IRepositorioProdutoDoPedido, RepositorioProdutoDoPedido>();
			servicos.AddTransient<IRepositorioMesa, RepositorioMesa>();
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		/// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
		private static void AddResolucaoDeAddResolucaoDeIdentidade(IServiceCollection servicos)
		{
			servicos.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
			servicos.AddTransient<IServicoDeUsuario, ServicoDeUsuarioImpl>();
			servicos.AddIdentity<Usuario, Role>(options =>
			{
				// SENHA
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;

				// LOCKOUT
				options.Lockout.AllowedForNewUsers = true;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;

				// USUARIO
				options.User.RequireUniqueEmail = true;

				// SIGNIN
				options.SignIn.RequireConfirmedEmail = false;
			})
				.AddEntityFrameworkStores<ContextoDeAplicacao>()
				.AddDefaultTokenProviders();
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		private static void AddResolucaoDeServicos(IServiceCollection servicos)
		{
			servicos.AddTransient<IServicoDeFuncionario, ServicoDeFuncionarioImpl>();
			servicos.AddTransient<IServicoDeComanda, ServicoDeComandaImpl>();
			servicos.AddTransient<IServicoDePedido, ServicoDePedidoImpl>();
			servicos.AddTransient<IServicoDeProduto, ServicoDeProdutoImpl>();
			servicos.AddTransient<IServicoDeMesa, ServicoDeMesaImpl>();
			servicos.AddTransient<IServicoDeProdutosDoPedido, ServicoDeProdutosDoPedidoImpl>();
			servicos.AddTransient<IServicoDeUsuario, ServicoDeUsuarioImpl>();
		}
	}
}
