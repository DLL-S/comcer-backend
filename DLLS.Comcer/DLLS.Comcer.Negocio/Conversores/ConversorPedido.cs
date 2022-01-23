using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorPedido : ConversorPadrao<Pedido, DtoPedido>, IConversorPedido
	{
		ConversorProduto conversorProduto;

		public override DtoPedido Converta(Pedido objeto)
		{
			var dto = base.Converta(objeto);
			dto.Produto = ConversorProduto().Converta(objeto.Produto);

			return dto;
		}

		public override Pedido Converta(DtoPedido dto)
		{
			var objeto = base.Converta(dto);
			objeto.Produto = ConversorProduto().Converta(dto.Produto);
			return objeto;
		}

		private ConversorProduto ConversorProduto()
		{
			return conversorProduto ??= new ConversorProduto();
		}
	}
}
