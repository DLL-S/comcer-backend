using System.Configuration;

namespace DLLS.Comcer.Infraestrutura
{
	public class ConnectionStringUtils
	{
		public static string ObtenhaStringDeConexao(string key)
		{
			string stringDeConexao = ConfigurationManager.ConnectionStrings[key].ConnectionString;
			return stringDeConexao;
		}
	}
}
