using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Utilitarios.Enumeradores;

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
		TObjeto Consulte(int codigo);

		/// <summary>
		/// Consulta todos os registros no contexto definido.
		/// </summary>
		/// <returns>Uma lista com os registros.</returns>
		IList<TObjeto> Liste();

		/// <summary>
		/// Consulta todos os registros que atendem a consulta no contexto definido.
		/// </summary>
		/// <returns>Uma lista com os registros que atendem a consulta.</returns>
		IList<TObjeto> Liste(Expression<Func<TObjeto, bool>> predicate);

		/// <summary>
		/// Consulta uma página de registros no contexto definido.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item.</param>
		/// <param name="quantidade">A quantidade de itens a retornar.</param>
		/// <param name="ordem">A ordem dos itens na lista.</param>
		/// <returns>Uma lista com os registros.</returns>
		IList<TObjeto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca);

		/// <summary>
		/// Atualiza um registro no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto modificado.</param>
		TObjeto Atualize(TObjeto objeto);

		/// <summary>
		/// Exclui um registro no contexto.
		/// </summary>
		/// <param name="codigo">O objeto a ser excluído.</param>
		void Exclua(int codigo);

		int Count();
	}
}
