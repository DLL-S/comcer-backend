using DLLS.Comcer.Dominio.Objetos.Funcionario;
using DLLS.Comcer.Interfaces.Conversores;
using DLLS.Comcer.Interfaces.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeFuncionarioImpl : ServicoPadraoImpl<Funcionario, DtoFuncionario>
	{
		public ServicoDeFuncionarioImpl(IRepositorioFuncionario repositorio, IConversorFuncionario conversor) : base(repositorio, conversor)
		{
		}
	}
}
