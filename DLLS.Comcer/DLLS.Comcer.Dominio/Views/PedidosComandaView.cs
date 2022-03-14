using System;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Dominio.Views
{
	public class PedidosComandaView
	{
		public virtual int IdComanda { get; set; }
		public virtual string NomeComanda { get; set; }
		public virtual decimal ValorTotalComanda { get; set; }
		public virtual EnumStatusComanda StatusComanda { get; set; }
		public virtual int IdDoProdutoDoPedido { get; set; }
		public virtual string NomeProdutoDoPedido { get; set; }
		public virtual string DescricaoProdutoDoPedido { get; set; }
		public virtual decimal PrecoProdutoDoPedido { get; set; }
		public virtual byte[] FotoProdutoDoPedido { get; set; }
		public virtual int QuantidadeProdutoDoPedido { get; set; }
		public virtual EnumStatusPedido StatusProdutoDoPedido { get; set; }
		public virtual DateTime DataHoraPedido { get; set; }
	}
}
