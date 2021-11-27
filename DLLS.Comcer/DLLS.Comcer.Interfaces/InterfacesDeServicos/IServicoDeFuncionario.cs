using System.Collections.Generic;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeFuncionario : IServicoPadrao<DtoFuncionario>
	{
		public DtoFuncionario AlterneAtivacao(long codigo);
		IList<DtoFuncionario> Consulte(string termoDeBusca, int quantidade, EnumOrdem ordem);
	}
}
