﻿using System;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.ModelosViews
{
	public class DtoPedidoProdutoView
	{
		public int NumeroMesa { get; set; }
		public int NumeroPedido { get; set; }
		public string ProdutoPedido { get; set; }
		public DateTime DataHoraPedido { get; set; }
		public EnumStatusPedido StatusPedido { get; set; }
	}
}