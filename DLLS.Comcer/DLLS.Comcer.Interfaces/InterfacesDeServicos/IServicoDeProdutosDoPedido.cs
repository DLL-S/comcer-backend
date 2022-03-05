using System.Collections.Generic;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeProdutosDoPedido : IServicoPadrao<DtoProdutoDoPedido>
	{
		public DtoSaida<DtoProdutoDoPedido> AtualizeStatus(int codigo, EnumStatusPedido status);
		public IList<DtoPedidoProdutoView> ListeItensDoPedido(int numeroPedido);
	}
}
