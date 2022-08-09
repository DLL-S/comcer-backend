using System;
using System.Collections.Generic;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoPedido : DtoBase
	{
		public IList<DtoProdutoDoPedido> ProdutosDoPedido { get; set; }

		public DateTime DataHoraPedido { get; set; }

		public string Observacao { get; set; }
	}
}
