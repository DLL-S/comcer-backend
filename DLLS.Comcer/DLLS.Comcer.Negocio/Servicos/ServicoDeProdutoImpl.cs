using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeProdutoImpl : ServicoPadraoImpl<Produto, DtoProduto>, IServicoDeProduto
	{
		private IConversorProduto _conversor;
		private IValidadorProduto _validador;

		public ServicoDeProdutoImpl(IRepositorioProduto repositorio) : base(repositorio)
		{
		}

		private IRepositorioProduto Repositorio()
		{
			return (IRepositorioProduto)_repositorio;
		}

		protected override IValidadorPadrao<Produto> Validador()
		{
			return _validador ??= new ValidadorProduto();
		}

		protected override IConversorPadrao<Produto, DtoProduto> Conversor()
		{
			return _conversor ??= new ConversorProduto();
		}
	}
}
