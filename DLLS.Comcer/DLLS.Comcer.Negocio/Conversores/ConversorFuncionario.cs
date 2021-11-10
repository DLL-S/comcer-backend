using DLLS.Comcer.Dominio.Objetos.Funcionario;
using DLLS.Comcer.Interfaces.Conversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorFuncionario : ConversorPadrao<Funcionario, DtoFuncionario>, IConversorFuncionario
	{
	}
}
