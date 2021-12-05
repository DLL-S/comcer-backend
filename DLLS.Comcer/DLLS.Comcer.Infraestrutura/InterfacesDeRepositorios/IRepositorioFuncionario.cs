using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios
{
	public interface IRepositorioFuncionario : IRepositorioObjetoComIdNumerico<Funcionario>
	{
		/// <summary>
		/// Altera a situacao de um Funcionario.
		/// </summary>
		/// <param name="codigo">O código do funcionário.</param>
		/// <returns>O <see cref="EnumSituacao"/> do funcionário.</returns>
		EnumSituacao AlterneAtivacao(int codigo);
	}
}
