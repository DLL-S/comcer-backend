using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;

namespace DLLS.Comcer.Interfaces.InterfacesDeConversores
{
	public interface IConversorProdutoDoPedido : IConversorPadrao<ProdutoDoPedido, DtoProdutoDoPedido>
	{
		public IList<DtoPedidoProdutoView> Converta(IList<PedidoProdutoView> obj);
		public DtoPedidoProdutoView Converta(PedidoProdutoView obj);
	}
}
