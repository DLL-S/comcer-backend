using System.Collections.Generic;
using DLLS.Comcer.Dominio.Views;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDePedido : IServicoPadrao<DtoPedido>
	{
		public IList<DtoPedidoView> ListePedidosView();

		public IList<DtoPedidosComandaView> ListePedidosComandaView();
	}
}
