using System;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura
{
	public abstract class FabricaDeContextoGenerico<T> where T : DbContext
	{
		public T CreateDbContext()
		{
			string stringDeConexao = ConnectionStringUtils.ObtenhaStringDeConexao();

			var builder = new DbContextOptionsBuilder<ContextoDeAplicacao>();
			builder.UseNpgsql(stringDeConexao, opcoes =>
				opcoes.MigrationsAssembly("DLLS.Comcer.Infraestrutura"));

			return (T)Activator.CreateInstance(typeof(T), new object[] { builder.Options });
		}
	}
}
