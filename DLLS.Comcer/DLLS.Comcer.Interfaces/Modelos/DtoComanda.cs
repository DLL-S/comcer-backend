using System;
using System.Collections.Generic;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoComanda : DtoBase
	{
		public string Nome { get; set; }

		public IList<DtoPedido> ListaPedidos { get; set; }

		public decimal Valor { get; set; }

		public EnumStatusComanda Status { get; set; }

		public DateTime AberturaComanda { get; set; }

		public DateTime? EncerramentoComanda { get; set; }
	}
}
