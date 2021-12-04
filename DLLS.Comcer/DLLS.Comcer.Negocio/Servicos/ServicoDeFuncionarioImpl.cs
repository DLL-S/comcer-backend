using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
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

		private IRepositorioFuncionario Repositorio()
		{
			return (IRepositorioFuncionario)_repositorio;
		}

		public DtoFuncionario AlterneAtivacao(long codigo)
		{
			var objeto = Repositorio().AlterneAtivacao(codigo);
			var dtoRetorno = _conversor.Converta(objeto);
			CentralDeValidacoes.inserirRetornoValidacao(ref dtoRetorno, objeto, (a) => new List<InconsistenciaDeValidacao>());
			return dtoRetorno;
		}

		public IList<DtoFuncionario> Consulte(string termoDeBusca, int quantidade, EnumOrdem ordem)
		{
			var lista = _conversor.Converta(Repositorio().Consulte(termoDeBusca, quantidade, ordem));

			return lista;
		}
	}
}
