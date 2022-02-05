using System;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoProdutoDoPedido : DtoBase
	{
		public DtoProduto Produto { get; set; }

		public int Quantidade { get; set; }

		public decimal ValorUnitario { get; set; }

		public EnumStatusPedido Status { get; set; }

		public DateTime DataHoraPedido { get; set; }
	}
}
