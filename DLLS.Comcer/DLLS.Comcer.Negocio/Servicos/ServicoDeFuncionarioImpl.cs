using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeFuncionarioImpl : ServicoPadraoImpl<Funcionario, DtoFuncionario>, IServicoDeFuncionario
	{
		private IConversorFuncionario _conversor;
		private IValidadorFuncionario _validador;

		public ServicoDeFuncionarioImpl(IRepositorioFuncionario repositorio) : base(repositorio)
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

		protected override IValidadorPadrao<Funcionario> Validador()
		{
			throw _validador ??= new ValidadorFuncionario();
		}

		protected override IConversorPadrao<Funcionario, DtoFuncionario> Conversor()
		{
			return _conversor ??= new ConversorFuncionario();
		}
	}
}
