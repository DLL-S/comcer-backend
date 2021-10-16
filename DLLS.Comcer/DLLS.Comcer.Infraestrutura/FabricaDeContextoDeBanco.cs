using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DLLS.Comcer.Infraestrutura
{
	public class FabricaDeContextoDeBanco : IDesignTimeDbContextFactory<ContextoPadrao>
	{
		public ContextoPadrao CreateDbContext(string[] args)
		{

			string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			IConfiguration configuracao = new ConfigurationBuilder()
					 .SetBasePath(Directory.GetCurrentDirectory())
				 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					 .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
				 .Build();

			string stringDeConexao = configuracao.GetConnectionString("DefaultConnection");

			var builder = new DbContextOptionsBuilder<ContextoPadrao>();
			builder.UseNpgsql(stringDeConexao, opcoes =>
				 opcoes.MigrationsAssembly("DLLS.Comcer.Infraestrutura"));

			return new ContextoPadrao(builder.Options);
		}
	}
}
