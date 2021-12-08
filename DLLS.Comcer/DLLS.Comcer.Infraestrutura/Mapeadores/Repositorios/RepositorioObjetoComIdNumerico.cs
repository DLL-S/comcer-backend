using System;
using System.Collections.Generic;
using System.Linq;
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
		public RepositorioObjetoComIdNumerico(ContextoDeAplicacao contexto)
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
		/// <param name="Codigo">O código do objeto.</param>
		/// <returns>O objeto da base, ou null caso não exista.</returns>
		public virtual TObjeto Consulte(int Codigo)
		{
			return Persistencia.Where(x => x.Id == Codigo).FirstOrDefault();
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

			if(string.IsNullOrEmpty(termoDeBusca))
				return ordem == EnumOrdem.ASC
					? Persistencia.OrderBy(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList()
					: Persistencia.OrderByDescending(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
			else
				return ListeComTermoDeBusca(pagina, quantidade, ordem, termoDeBusca);
		}

		/// <summary>
		/// Atualiza um registro no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto modificado.</param>
		public virtual TObjeto Atualize(TObjeto objeto)
		{
			Persistencia.Update(objeto);
			Contexto.SaveChanges();

			return objeto;
		}

		/// <summary>
		/// Exclui um registro no contexto.
		/// </summary>
		/// <param name="objeto">O objeto a ser excluído.</param>
		public virtual void Exclua(int objeto)
		{
			Persistencia.Remove(Consulte(objeto));
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
	}
}
