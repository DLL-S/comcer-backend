using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios
{
	public class RepositorioProdutoDoPedido : RepositorioObjetoComIdNumerico<ProdutoDoPedido>, IRepositorioProdutoDoPedido
	{
		/// <summary>
		/// Construtor padrão.
		/// </summary>
		/// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
		public RepositorioProdutoDoPedido(ContextoDeAplicacao contexto)
			: base(contexto) { }

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		protected override IList<ProdutoDoPedido> ListeComTermoDeBusca(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			return ordem == EnumOrdem.ASC
				? Persistencia.OrderBy(x => x.DataHoraPedido).Where(x => string.IsNullOrEmpty(termoDeBusca)
					|| (int)x.Status == int.Parse(termoDeBusca)
					).Skip((pagina - 1) * quantidade).Take(quantidade).ToList()
					: Persistencia.OrderByDescending(x => x.DataHoraPedido).Where(x => string.IsNullOrEmpty(termoDeBusca)
					|| (int)x.Status == int.Parse(termoDeBusca)
					).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
		}
	}
}
