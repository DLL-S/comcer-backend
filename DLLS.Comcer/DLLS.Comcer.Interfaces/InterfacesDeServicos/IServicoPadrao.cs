using System.Collections.Generic;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoPadrao<TDto> where TDto : DtoBase
	{
		/// <summary>
		/// Consulta um item pelo código.
		/// </summary>
		/// <param name="codigo">O código do item a ser pesquisado.</param>
		/// <returns>Um Dto com o item encontrado ou null.</returns>
		TDto Consulte(int condigo);

		/// <summary>
		/// Retorna uma lista com todos os registros da base (Utilize com cuidado).
		/// </summary>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		IList<TDto> Liste();

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		IList<TDto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca);

		/// <summary>
		/// Cadastrda um novo item na base.
		/// </summary>
		/// <param name="dto">O Dto a ser cadastrado.</param>
		/// <returns>Retorna o Dto com uma indicação de Sucesso true ou false.</returns>
		TDto Cadastre(TDto objeto);

		/// <summary>
		/// Atualiza um item na base.
		/// </summary>
		/// <param name="dto">O Dto do item a ser atualizado.</param>
		/// <returns>Retorna o Dto com uma indicação de Sucesso true ou false.</returns>
		TDto Atualize(TDto objeto);

		/// <summary>
		/// Exclui um itm da base de dados.
		/// </summary>
		/// <param name="codigo">O código do item a ser excluído</param>
		void Exclua(int codigo);
	}
}
