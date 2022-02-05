using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeConversores
{
	public interface IConversorFuncionario : IConversorPadrao<Funcionario, DtoFuncionario>
	{
	}
}
