using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Utilitarios.Enumeradores;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios
{
	public class RepositorioProduto : RepositorioObjetoComIdNumerico<Produto>, IRepositorioProduto
	{
		/// <summary>
		/// Construtor padrão.
		/// </summary>
		/// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
		public RepositorioProduto(ContextoDeAplicacao contexto)
			: base(contexto) { }

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		protected override IList<Produto> ListeComTermoDeBusca(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			// c => EF.Functions.Collate(c.Name, "SQL_Latin1_General_CP1_CI_AS") == "John"
			return ordem == EnumOrdem.ASC
				? Persistencia
					.Where(x => EF.Functions.ILike(x.Nome, termoDeBusca))
					.OrderBy(x => x.Id)
					.Skip((pagina - 1) * quantidade)
					.Take(quantidade)
					.ToList()
				: Persistencia
					.Where(x => EF.Functions.ILike(x.Nome, termoDeBusca))
					.OrderByDescending(x => x.Id)
					.Skip((pagina - 1) * quantidade)
					.Take(quantidade)
					.ToList();
		}
	}
}
