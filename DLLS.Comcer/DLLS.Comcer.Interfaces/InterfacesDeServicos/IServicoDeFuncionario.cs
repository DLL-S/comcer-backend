using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeFuncionario : IServicoPadrao<DtoFuncionario>
	{
		public DtoFuncionario AlterneAtivacao(long codigo);
	}
}
