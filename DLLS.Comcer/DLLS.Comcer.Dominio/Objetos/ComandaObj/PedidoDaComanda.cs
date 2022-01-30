using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Dominio.Objetos.ProdutoObj;

namespace DLLS.Comcer.Dominio.Objetos.ComandaObj
{
	public class PedidoDaComanda
	{
		public Pedido pedido { get; set; }
		public Produto Produto { get; set; }
	}
}
