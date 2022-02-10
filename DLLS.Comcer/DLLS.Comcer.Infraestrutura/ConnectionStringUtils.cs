using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DLLS.Comcer.Infraestrutura
{
	public class ConnectionStringUtils
	{
		public static string ObtenhaStringDeConexao(string key)
		{
			string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			string stringDeConexao = Environment.GetEnvironmentVariable(
				ambiente?.ToUpper() == "DEVELOPMENT" ?
				"connectionStringDev" :
				"connectionString");

			return stringDeConexao;
		}
	}
}
