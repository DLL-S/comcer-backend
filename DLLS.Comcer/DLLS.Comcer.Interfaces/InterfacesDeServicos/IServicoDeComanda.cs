using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeComanda : IServicoPadrao<DtoComanda>
	{
		DtoSaida<DtoComanda> IncluaPedido(int codigoComanda, DtoPedido pedido);
		DtoComanda TrateInclusaoDeComanda(DtoComanda comanda);
		DtoComanda ObtenhaComandaDoProdutoPedido(int codigoProdutoDoPedido);
		DtoSaida<DtoComanda> EncerrarComanda(int codigo, bool paraPagamento);
	}
}
