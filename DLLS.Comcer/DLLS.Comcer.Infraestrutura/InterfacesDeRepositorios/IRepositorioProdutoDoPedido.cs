using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Interfaces.ModelosViews;

namespace DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios
{
	public interface IRepositorioProdutoDoPedido : IRepositorioObjetoComIdNumerico<ProdutoDoPedido>
	{
		public IList<PedidoProdutoView> ListePedidoDoProdutoView(int numeroPedido);
	}
}
