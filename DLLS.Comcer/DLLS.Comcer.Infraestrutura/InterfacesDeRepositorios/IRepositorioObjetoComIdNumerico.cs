using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;

namespace DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios
{
	public interface IRepositorioObjetoComIdNumerico<TObjeto> : IRepositorioGenerico<TObjeto>
		 where TObjeto : ObjetoComIdNumerico
	{
		/// <summary>
		/// Cadastra um novo objeto no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto a ser cadastrado.</param>
		TObjeto Cadastre(TObjeto objeto);

		/// <summary>
		/// Consulta um objeto no contexto definido.
		/// </summary>
		/// <param name="codigo">O código do objeto.</param>
		/// <returns>O objeto da base, ou null caso não exista.</returns>
		TObjeto Consulte(long codigo);

		/// <summary>
		/// Consulta todos os registros no contexto definido.
		/// </summary>
		/// <returns>Uma lista com os registros.</returns>
		IList<TObjeto> ConsulteLista();

		/// <summary>
		/// Consulta uma página de registros no contexto definido.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item.</param>
		/// <param name="quantidade">A quantidade de itens a retornar.</param>
		/// <param name="ordem">A ordem dos itens na lista.</param>
		/// <returns>Uma lista com os registros.</returns>
		IList<TObjeto> ConsulteLista(int pagina, int quantidade, EnumOrdem ordem);

		/// <summary>
		/// Atualiza um registro no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto modificado.</param>
		TObjeto Atualize(TObjeto objeto);

		/// <summary>
		/// Exclui um registro no contexto.
		/// </summary>
		/// <param name="objeto">O objeto a ser excluído.</param>
		void Exclua(long Codigo);
	}
}
