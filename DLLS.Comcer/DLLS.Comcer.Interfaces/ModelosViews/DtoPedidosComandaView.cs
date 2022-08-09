using System;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.ModelosViews
{
	public class DtoPedidosComandaView
	{
		public int IdComanda { get; set; }
		public string NomeComanda { get; set; }
		public decimal ValorTotalComanda { get; set; }
		public EnumStatusComanda StatusComanda { get; set; }
		public int IdDoProdutoDoPedido { get; set; }
		public string NomeProdutoDoPedido { get; set; }
		public string DescricaoProdutoDoPedido { get; set; }
		public string Observacao { get; set; }
		public decimal PrecoProdutoDoPedido { get; set; }
		public byte[] FotoProdutoDoPedido { get; set; }
		public int QuantidadeProdutoDoPedido { get; set; }
		public EnumStatusPedido StatusProdutoDoPedido { get; set; }
		public DateTime DataHoraPedido { get; set; }
	}
}
