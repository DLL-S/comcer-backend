using System;
using DLLS.Comcer.Infraestrutura;
using DLLS.Comcer.Startup.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLLS.Comcer.Startup
{
    public static class InjecaoDeDependencias
	{
		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		/// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
		public static void AddResolucaoDeAddResolucaoDeIdentidade(this IServiceCollection servicos, IConfiguration configuracao)
		{
			servicos.AddDbContext<ContextoPadrao>(options => options.UseNpgsql(configuracao.GetConnectionString("DefaultConnection")));
			servicos.AddIdentityCore<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
									 .AddEntityFrameworkStores<ContextoPadrao>();
		}
		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		/// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
		public static void AddResolucaoDeBancoDeDados(this IServiceCollection servicos, IConfiguration configuracao)
		{
			servicos.AddDbContext<ContextoPadrao>(options => options.UseNpgsql(configuracao.GetConnectionString("DefaultConnection")));
		}

		/// <summary>
		/// Método de extênsão para a configuração de serviços da aplicação.
		/// </summary>
		/// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
		public static void AddResolucaoDeServicos(this IServiceCollection servicos)
		{
			//servicos.AddTransient<IRepositorioVideo, RepositorioVideo>();
		}


	}
}
