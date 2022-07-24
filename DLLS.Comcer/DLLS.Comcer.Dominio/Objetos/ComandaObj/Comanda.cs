using System;
using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Dominio.Objetos.ComandaObj
{
	public class Comanda : ObjetoComIdNumerico
	{
		public const int TAMANHO_MAXIMO_NOME = 80;

		public virtual string Nome { get; set; }

		public virtual IList<Pedido> ListaPedidos { get; set; }

		public virtual decimal Valor { get; set; }

		public virtual EnumStatusComanda Status { get; set; }

		public virtual DateTime AberturaComanda { get; set; }

		public virtual DateTime? EncerramentoComanda { get; set; }

		public override int CompareTo(object obj)
		{
			Comanda Temp = (Comanda)obj;
			if (this.Status != Temp.Status)
				return this.Status == EnumStatusComanda.AGUARDANDO_PAGAMENTO ? 1 : -1;
			else
				return 0;
		}
	}
}
