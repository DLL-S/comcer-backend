using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeProdutosDoPedido : IServicoPadrao<DtoPedidoProduto>
	{
		public DtoSaida<DtoPedidoProduto> AtualizeStatus(int codigo, EnumStatusPedido status);
	}
}
