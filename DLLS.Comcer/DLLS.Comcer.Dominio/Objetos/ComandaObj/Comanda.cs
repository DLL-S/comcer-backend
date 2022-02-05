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
	}
}
