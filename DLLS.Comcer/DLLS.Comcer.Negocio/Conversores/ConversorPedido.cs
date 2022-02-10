using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorPedido : ConversorPadrao<Pedido, DtoPedido>, IConversorPedido
	{
		private ConversorProdutoDoPedido conversorProduto;

		public override DtoPedido Converta(Pedido objeto)
		{
			DtoPedido dto = base.Converta(objeto);
			dto.ProdutosDoPedido = ConversorProdutoDoPedido().Converta(objeto.ProdutosDoPedido);

			return dto;
		}

		public override Pedido Converta(DtoPedido dto)
		{
			Pedido objeto = base.Converta(dto);
			objeto.ProdutosDoPedido = ConversorProdutoDoPedido().Converta(dto.ProdutosDoPedido);
			return objeto;
		}

		private ConversorProdutoDoPedido ConversorProdutoDoPedido()
		{
			return conversorProduto ??= new ConversorProdutoDoPedido();
		}
	}
}
