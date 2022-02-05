using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeProdutosDoPedidoImpl : ServicoPadraoImpl<ProdutoDoPedido, DtoPedidoProduto>, IServicoDeProdutosDoPedido
	{
		private IConversorProdutoDoPedido _conversor;
		private IValidadorProdutoDoPedido _validador;

		public ServicoDeProdutosDoPedidoImpl(IRepositorioProdutoDoPedido repositorio) : base(repositorio)
		{
		}

		private IRepositorioProdutoDoPedido Repositorio()
		{
			return (IRepositorioProdutoDoPedido)_repositorio;
		}

		protected override IValidadorPadrao<ProdutoDoPedido> Validador()
		{
			return _validador ??= new ValidadorProdutoDoPedido();
		}

		protected override IConversorPadrao<ProdutoDoPedido, DtoPedidoProduto> Conversor()
		{
			return _conversor ??= new ConversorProdutoDoPedido();
		}

		public DtoSaida<DtoPedidoProduto> AtualizeStatus(int codigo, EnumStatusPedido status)
		{
			throw new System.NotImplementedException();
		}
	}
}