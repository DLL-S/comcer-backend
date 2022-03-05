using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Interfaces.ModelosViews;

namespace DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios
{
	public interface IRepositorioPedido : IRepositorioObjetoComIdNumerico<Pedido>
	{
		public IList<PedidoView> ObtenhaPedidos();
	}
}
