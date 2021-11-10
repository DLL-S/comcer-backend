using DLLS.Comcer.Infraestrutura;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios;
using DLLS.Comcer.Interfaces.Conversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLLS.Comcer.Startup
{
	public static class InjecaoDeDependencias
	{
		public static void AddResolucaoDeDependencias(this IServiceCollection servicos, IConfiguration configuracao)
		{
			servicos.AddResolucaoDeConversores();
			servicos.AddResolucaoDeAddResolucaoDeIdentidade(configuracao);
			servicos.AddResolucaoDeBancoDeDados(configuracao);
			servicos.AddResolucaoDeServicos();

		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		/// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
		private static void AddResolucaoDeAddResolucaoDeIdentidade(this IServiceCollection servicos, IConfiguration configuracao)
		{
			//servicos.AddDbContext<ContextoPadrao>(options => options.UseNpgsql(configuracao.GetConnectionString("DefaultConnection")));
			//servicos.AddIdentityCore<Usuario>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContextoPadrao>();
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		/// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
		private static void AddResolucaoDeBancoDeDados(this IServiceCollection servicos, IConfiguration configuracao)
		{
			servicos.AddDbContext<ContextoPadrao>(options => options.UseNpgsql(configuracao.GetConnectionString("DefaultConnection")));

			servicos.AddTransient<IRepositorioFuncionario, RepositorioFuncionario>();
			servicos.AddTransient(typeof(IRepositorioObjetoComIdNumerico<>), typeof(RepositorioObjetoComIdNumerico<>));
			//servicos.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		private static void AddResolucaoDeServicos(this IServiceCollection servicos)
		{
			servicos.AddTransient<IServicoDeFuncionario, ServicoDeFuncionarioImpl>();
			//servicos.AddTransient(typeof(IServicoPadrao<>), typeof(ServicoPadraoImpl<,>));
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		private static void AddResolucaoDeConversores(this IServiceCollection servicos)
		{
			servicos.AddTransient<IConversorFuncionario, ConversorFuncionario>();
			servicos.AddTransient(typeof(IConversorPadrao<,>), typeof(ConversorPadrao<,>));
			//servicos.AddTransient(typeof(IServicoPadrao<>), typeof(ServicoPadraoImpl<,>));
		}
	}
}
