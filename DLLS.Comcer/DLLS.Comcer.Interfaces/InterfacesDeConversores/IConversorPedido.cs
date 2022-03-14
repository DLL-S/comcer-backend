using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Dominio.Views;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;

namespace DLLS.Comcer.Interfaces.InterfacesDeConversores
{
	public interface IConversorPedido : IConversorPadrao<Pedido, DtoPedido>
	{
		public IList<DtoPedidosComandaView> Converta(IList<PedidosComandaView> obj);
		public DtoPedidosComandaView Converta(PedidosComandaView obj);
		public IList<DtoPedidoView> Converta(IList<PedidoView> obj);
		public DtoPedidoView Converta(PedidoView obj);
	}
}
