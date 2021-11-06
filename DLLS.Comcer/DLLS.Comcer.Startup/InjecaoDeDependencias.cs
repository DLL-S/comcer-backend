using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLS.Comcer.Infraestrutura;
using DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios;
using DLLS.Comcer.Interfaces.InterfacesDeRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLLS.Comcer.Startup
{
    public static class InjecaoDeDependencias
    {
		public static void AddResolucaoDeDependencias(this IServiceCollection servicos, IConfiguration configuracao)
        {
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
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		private static void AddResolucaoDeServicos(this IServiceCollection servicos)
		{
			//servicos.AddTransient<IRepositorioVideo, RepositorioVideo>();
		}
	}
}
