using System.Collections.Generic;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoComanda : DtoBase
	{
		//public DtoComanda(Mesa mesa)
		//{
		//	Nome = "Mesa " + mesa.codigo;
		//}

		public string Nome { get; set; }

		public IList<DtoPedido> ListaPedidos { get; set; }

		public decimal Valor { get; set; }

		public EnumStatusComanda Status { get; set; }

		//public Mesa mesa { get; set; }
	}
}
