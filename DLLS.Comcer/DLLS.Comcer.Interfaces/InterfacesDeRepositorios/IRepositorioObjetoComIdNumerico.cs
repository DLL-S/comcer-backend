using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;

namespace DLLS.Comcer.Interfaces.InterfacesDeRepositorios
{
	public interface IRepositorioObjetoComIdNumerico<TObjeto> : IRepositorioGenerico<TObjeto>
		 where TObjeto : ObjetoComIdNumerico
	{
		/// <summary>
		/// Cadastra um novo objeto no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto a ser cadastrado.</param>
		void Cadastre(TObjeto objeto);

		/// <summary>
		/// Consulta um objeto no contexto definido.
		/// </summary>
		/// <param name="Codigo">O código do objeto.</param>
		/// <returns>O objeto da base, ou null caso não exista.</returns>
		TObjeto Consulte(long Codigo);

		/// <summary>
		/// Consulta todos os registros no contexto definido.
		/// </summary>
		/// <returns>Uma lista com os registros.</returns>
		IList<TObjeto> ConsulteLista();

		/// <summary>
		/// Atualiza um registro no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto modificado.</param>
		void Atualize(TObjeto objeto);

		/// <summary>
		/// Exclui um registro no contexto.
		/// </summary>
		/// <param name="objeto">O objeto a ser excluído.</param>
		void Exclua(long Codigo);
	}
}
