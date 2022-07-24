using System;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Utilitarios.Globalizacoes;
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
			var usuarioLogado = Persistencia.FirstOrDefault(x => usuario == x.Email && x.PasswordHash == senha);

			if (usuarioLogado is null || usuarioLogado.Funcionario.Situacao == Utilitarios.Enumeradores.EnumSituacao.ATIVO)
			{
				return usuarioLogado;
			}

			throw new ArgumentException(Globalizacoes.UsuarioInativo);
		}
	}
}
