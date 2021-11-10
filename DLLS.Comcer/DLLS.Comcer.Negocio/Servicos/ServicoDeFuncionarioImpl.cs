using DLLS.Comcer.Dominio.Objetos.Funcionario;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.Conversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeFuncionarioImpl : ServicoPadraoImpl<Funcionario, DtoFuncionario>, IServicoDeFuncionario
	{
		public ServicoDeFuncionarioImpl(IRepositorioFuncionario repositorio, IConversorFuncionario conversor) : base(repositorio, conversor)
		{
		}

		public DtoFuncionario AlterneAtivacao(long codigo)
		{
			return _conversor.Converta(((IRepositorioFuncionario)_repositorio).AlterneAtivacao(codigo));
		}
	}
}
