using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeFuncionario : IServicoPadrao<DtoFuncionario>
	{
		/// <summary>
		/// Altera a situacao de um Funcionario.
		/// </summary>
		/// <param name="codigo">O código do funcionário.</param>
		/// <returns>O Dto do funcionário.</returns>
		public EnumSituacao AlterneSituacao(int codigo);
	}
}
