using DLLS.Comcer.Dominio.Objetos.Usuario;
using DLLS.Comcer.Infraestrutura.Contextos;
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
			AddResolucaoDeBancoDeDados(servicos, configuracao);
			AddResolucaoDeAddResolucaoDeIdentidade(servicos, configuracao);
			AddResolucaoDeServicos(servicos);
			AddResolucaoDeConversores(servicos);
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		/// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
		private static void AddResolucaoDeBancoDeDados(IServiceCollection servicos, IConfiguration configuracao)
		{
			servicos.AddDbContext<ContextoDeAplicacao>(options => options.UseNpgsql(configuracao.GetConnectionString("DefaultConnection")));

			servicos.AddTransient<IRepositorioFuncionario, RepositorioFuncionario>();
			servicos.AddTransient(typeof(IRepositorioObjetoComIdNumerico<>), typeof(RepositorioObjetoComIdNumerico<>));
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		/// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
		private static void AddResolucaoDeAddResolucaoDeIdentidade(IServiceCollection servicos, IConfiguration configuracao)
		{
			servicos.AddDbContext<ContextoDeIdentidade>(options => options.UseNpgsql(configuracao.GetConnectionString("DefaultConnection")));
			servicos.AddIdentityCore<Usuario>(options => options.SignIn.RequireConfirmedEmail = true).AddEntityFrameworkStores<ContextoDeIdentidade>();
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		private static void AddResolucaoDeServicos(IServiceCollection servicos)
		{
			servicos.AddTransient<IServicoDeFuncionario, ServicoDeFuncionarioImpl>();
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		private static void AddResolucaoDeConversores(IServiceCollection servicos)
		{
			servicos.AddTransient<IConversorFuncionario, ConversorFuncionario>();
		}
	}
}
