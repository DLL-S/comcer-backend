using System;
using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;

namespace DLLS.Comcer.Dominio.Objetos.PedidoObj
{
	public class Pedido : ObjetoComIdNumerico
	{
		public virtual IList<ProdutoDoPedido> ProdutosDoPedido { get; set; }

		public virtual DateTime DataHoraPedido { get; set; }

		public virtual string Observacao { get; set; }
	}
}
