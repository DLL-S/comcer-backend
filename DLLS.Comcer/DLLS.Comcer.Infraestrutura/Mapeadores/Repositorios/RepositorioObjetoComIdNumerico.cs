using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios
{
	public abstract class RepositorioObjetoComIdNumerico<TObjeto> : RepositorioGenerico<TObjeto>, IRepositorioObjetoComIdNumerico<TObjeto>
		 where TObjeto : ObjetoComIdNumerico
	{
		/// <summary>
		/// Construtor padrão.
		/// </summary>
		/// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
		protected RepositorioObjetoComIdNumerico(ContextoDeAplicacao contexto)
			 : base(contexto) { }

		/// <summary>
		/// Cadastra um novo objeto no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto a ser cadastrado.</param>
		public virtual TObjeto Cadastre(TObjeto objeto)
		{
			Persistencia.Add(objeto);
			Contexto.SaveChanges();

			return objeto;
		}

		/// <summary>
		/// Consulta um objeto no contexto definido.
		/// </summary>
		/// <param name="codigo">O código do objeto.</param>
		/// <returns>O objeto da base, ou null caso não exista.</returns>
		public virtual TObjeto Consulte(int codigo)
		{
			return Persistencia.Where(x => x.Id == codigo).FirstOrDefault();
		}

		/// <summary>
		/// Consulta todos os registros no contexto definido.
		/// </summary>
		/// <returns>Uma lista com os registros.</returns>
		public virtual IList<TObjeto> Liste()
		{
			return Persistencia.OrderBy(x => x.Id).ToList();
		}

		/// <summary>
		/// Consulta todos os registros no contexto definido.
		/// </summary>
		/// <returns>Uma lista com os registros.</returns>
		public virtual IList<TObjeto> Liste(Expression<Func<TObjeto, bool>> predicate)
		{
			return Persistencia.Where(predicate).ToList();
		}

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Objetos com os registros.</returns>
		public virtual IList<TObjeto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			pagina = pagina < 1 ? 1 : pagina;
			quantidade = quantidade < 1 ? 50 : quantidade;
			ordem = !Enum.IsDefined(ordem) ? EnumOrdem.ASC : ordem;

			if (string.IsNullOrEmpty(termoDeBusca))
				return ordem == EnumOrdem.ASC
					? Persistencia.OrderBy(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList()
					: Persistencia.OrderByDescending(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
			else
				return ListeComTermoDeBusca(pagina, quantidade, ordem, termoDeBusca);
		}

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Objetos com os registros.</returns>
		public virtual IList<TObjeto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoBuscado, string termoDeBusca)
		{
			pagina = pagina < 1 ? 1 : pagina;
			quantidade = quantidade < 1 ? 50 : quantidade;
			ordem = !Enum.IsDefined(ordem) ? EnumOrdem.ASC : ordem;

			if (string.IsNullOrEmpty(termoDeBusca))
				return ordem == EnumOrdem.ASC
					? Persistencia.OrderBy(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList()
					: Persistencia.OrderByDescending(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
			else
				return ListeComTermoDeBuscaV2(pagina, quantidade, ordem, termoBuscado, termoDeBusca);
		}

		private IList<TObjeto> ListeComTermoDeBuscaV2(int pagina, int quantidade, EnumOrdem ordem, string termoBuscado, string termoDeBusca)
		{
			var expression = ObtenhaFiltro(termoBuscado, termoDeBusca);

			var consulta = Persistencia.Where(expression);

			return ordem == EnumOrdem.ASC
					? consulta.OrderBy(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList()
					: consulta.OrderByDescending(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
		}

		private Func<TObjeto, bool> ObtenhaFiltro(string termoBuscado, string termoDeBusca)
		{
			var debugCompare = typeof(TObjeto).GetProperties();

			return (Objeto) =>
			{

				var prop = typeof(TObjeto).GetProperties().First(prop => prop.Name.ToUpper() == termoBuscado.ToUpper());
				return prop.GetValue(Objeto).ToString().Contains(termoDeBusca);
			};
		}

		/// <summary>
		/// Atualiza um registro no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto modificado.</param>
		public virtual TObjeto Atualize(TObjeto objeto)
		{
			Contexto.ChangeTracker.Clear();
			Persistencia.Update(objeto);
			Contexto.SaveChanges();

			return objeto;
		}

		/// <summary>
		/// Exclui um registro no contexto.
		/// </summary>
		/// <param name="objeto">O objeto a ser excluído.</param>
		public virtual void Exclua(int codigo)
		{
			Persistencia.Remove(Consulte(codigo));
			Contexto.SaveChanges();
		}

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Objetos com os registros.</returns>
		protected abstract IList<TObjeto> ListeComTermoDeBusca(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca);

		public int Count()
		{
			return Persistencia.Count();
		}
	}
}
