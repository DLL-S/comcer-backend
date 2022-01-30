﻿using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Dominio.Objetos.PedidoObj
{
	public class Pedido : ObjetoComIdNumerico
	{
		public virtual int IdProduto { get; set; }

		public virtual int Quantidade { get; set; }

		public virtual decimal ValorUnitario { get; set; }

		public virtual EnumStatusPedido Status { get; set; }
	}
}
