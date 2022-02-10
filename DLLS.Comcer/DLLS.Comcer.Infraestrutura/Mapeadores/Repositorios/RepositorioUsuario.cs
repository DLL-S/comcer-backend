using System.Linq;
using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios
{
	public class RepositorioUsuario : IRepositorioUsuario
	{
		protected readonly ContextoDeAplicacao Contexto;
		protected readonly DbSet<Usuario> Persistencia;

		/// <summary>
		/// Construtor padrão.
		/// </summary>
		/// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
		public RepositorioUsuario(ContextoDeAplicacao contexto)
		{
			Contexto = contexto;
			Persistencia = Contexto.Set<Usuario>();
		}

		public Usuario Cadastre(Usuario usuario)
		{
			Persistencia.Add(usuario);
			Contexto.SaveChanges();

			return usuario;
		}

		public Usuario ConsultePorLogin(string usuario, string senha)
		{
			return Persistencia.FirstOrDefault(x => usuario == x.Email && x.PasswordHash == senha);
		}
	}
}
