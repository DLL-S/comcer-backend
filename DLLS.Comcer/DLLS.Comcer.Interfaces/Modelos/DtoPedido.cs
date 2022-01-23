using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoPedido : DtoBase
	{
		public DtoProduto Produto { get; set; }

		public int Quantidade { get; set; }

		public decimal ValorUnitario { get; set; }

		public EnumStatusPedido Status { get; set; }
	}
}
