using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.ModelosViews
{
	public class PedidoView
	{
		public virtual int NumeroMesa { get; set; }
		public virtual int NumeroPedido { get; set; }
		public virtual EnumStatusPedido StatusPedido { get; set; }
	}
}
