using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DLLS.Comcer.Infraestrutura
{
	public static class ConnectionStringUtils
	{
		public static string ObtenhaStringDeConexao()
		{
			bool ehDesenvolvimento = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

			string stringDeConexao = ehDesenvolvimento ?
				ObtenhaStringDeConexaoDev() :
				ObterStringDeConexaoHeroku();

			return stringDeConexao;
		}

		private static string ObtenhaStringDeConexaoDev()
		{
			string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfiguration configuracao = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{ambiente}.json", optional: true)
				.AddEnvironmentVariables()
				.Build();

			string stringDeConexao = configuracao.GetConnectionString("connectionStringDev");
			return stringDeConexao;
		}

		private static string ObterStringDeConexaoHeroku()
		{
			string connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
			var databaseUri = new Uri(connectionUrl);

			string db = databaseUri.LocalPath.TrimStart('/');
			string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

			return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};" +
					$"Port={databaseUri.Port};Database={db};Pooling=true;" +
					$"SSL Mode=Require;Trust Server Certificate=True;";
		}
	}
}
