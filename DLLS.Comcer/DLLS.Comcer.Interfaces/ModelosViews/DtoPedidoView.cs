using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.ModelosViews
{
	public class DtoPedidoView
	{
		public int NumeroMesa { get; set; }
		public int NumeroPedido { get; set; }
		public string Observacao { get; set; }
		public EnumStatusPedido StatusPedido { get; set; }
	}
}
