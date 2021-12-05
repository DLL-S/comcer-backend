using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.Conversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeFuncionarioImpl : ServicoPadraoImpl<Funcionario, DtoFuncionario>, IServicoDeFuncionario
	{
		public ServicoDeFuncionarioImpl(IRepositorioFuncionario repositorio, IConversorFuncionario conversor) : base(repositorio, conversor)
		{
		}

		private IRepositorioFuncionario Repositorio()
		{
			return (IRepositorioFuncionario)_repositorio;
		}

		/// <summary>
		/// Altera a situacao de um Funcionario.
		/// </summary>
		/// <param name="codigo">O código do funcionário.</param>
		/// <returns>O Dto do funcionário.</returns>
		public EnumSituacao AlterneSituacao(int codigo)
		{
			return Repositorio().AlterneAtivacao(codigo);
		}
	}
}
