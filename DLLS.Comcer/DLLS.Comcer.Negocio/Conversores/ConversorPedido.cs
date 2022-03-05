using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;

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

		public IList<DtoPedidoView> Converta(IList<PedidoView> obj)
		{
			var lista = new List<DtoPedidoView>();
			foreach (PedidoView item in obj)
			{
				lista.Add(Converta(item));
			}

			return lista;
		}

		public DtoPedidoView Converta(PedidoView obj)
		{
			return Copie<DtoPedidoView, PedidoView>(obj);
		}

		private ConversorProdutoDoPedido ConversorProdutoDoPedido()
		{
			return conversorProduto ??= new ConversorProdutoDoPedido();
		}
	}
}
