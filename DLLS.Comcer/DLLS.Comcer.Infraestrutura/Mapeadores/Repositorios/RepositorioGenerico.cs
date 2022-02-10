using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios
{
	public abstract class RepositorioGenerico<TObjeto> : IRepositorioGenerico<TObjeto>
		where TObjeto : ObjetoComIdNumerico
	{
		protected readonly ContextoDeAplicacao Contexto;
		protected readonly DbSet<TObjeto> Persistencia;

		/// <summary>
		/// Construtor padrão.
		/// </summary>
		/// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
		protected RepositorioGenerico(ContextoDeAplicacao contexto)
		{
			Contexto = contexto;
			Persistencia = Contexto.Set<TObjeto>();
		}

	}
}
