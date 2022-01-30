using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DLLS.Comcer.Infraestrutura
{
	public abstract class FabricaDeContextoGenerico<T> where T : DbContext
	{
		public T CreateDbContext(string[] args)
		{
			string stringDeConexao = ObtenhaStringDeConexao();

			var builder = new DbContextOptionsBuilder<ContextoDeAplicacao>();
			builder.UseNpgsql(stringDeConexao, opcoes =>
				opcoes.MigrationsAssembly("DLLS.Comcer.Infraestrutura"));

			return (T)Activator.CreateInstance(typeof(T), new object[] { builder.Options });
		}

		private static string ObtenhaStringDeConexao()
		{
			string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfiguration configuracao = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{ambiente}.json", optional: true)
				.AddEnvironmentVariables()
				.Build();

			string stringDeConexao = configuracao.GetConnectionString("DefaultConnection");
			return stringDeConexao;
		}
	}
}
