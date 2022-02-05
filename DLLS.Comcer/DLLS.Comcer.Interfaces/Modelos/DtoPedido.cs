using System;
using System.Collections.Generic;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoPedido : DtoBase
	{
		public IList<DtoPedidoProduto> PedidosDoProduto { get; set; }

		public DateTime DataHoraPedido { get; set; }
	}
}
