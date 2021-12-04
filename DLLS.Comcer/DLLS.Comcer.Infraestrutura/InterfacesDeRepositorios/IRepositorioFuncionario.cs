using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;

namespace DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios
{
	public interface IRepositorioFuncionario : IRepositorioObjetoComIdNumerico<Funcionario>
	{
		Funcionario AlterneAtivacao(long codigo);

		/// <summary>
		/// Consulta uma lista de objetos no contexto definido.
		/// </summary>
		/// <param name="termoDeBusca">O termo de busca da filtragem.</param>
		/// <param name="quantidade">A quantidade de itens a retornar.</param>
		/// <param name="ordem">A ordem da lista.</param>
		/// <returns>A lista de itens filtrados.</returns>
		IList<Funcionario> Consulte(string termoDeBusca, int quantidade, EnumOrdem ordem);
	}
}
