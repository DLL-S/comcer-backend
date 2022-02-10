using System;

namespace DLLS.Comcer.Infraestrutura
{
	public static class ConnectionStringUtils
	{
		public static string ObtenhaStringDeConexao()
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
