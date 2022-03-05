using System;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.ModelosViews
{
	public class PedidoProdutoView
	{
		public virtual int NumeroMesa { get; set; }
		public virtual int NumeroPedido { get; set; }
		public virtual string ProdutoPedido { get; set; }
		public virtual DateTime DataHoraPedido { get; set; }
		public virtual EnumStatusPedido StatusPedido { get; set; }
	}
}
