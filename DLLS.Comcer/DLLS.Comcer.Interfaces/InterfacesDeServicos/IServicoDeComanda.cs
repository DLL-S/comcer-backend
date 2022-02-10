using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeComanda : IServicoPadrao<DtoComanda>
	{
		DtoSaida<DtoComanda> IncluaPedido(int codgoComanda, DtoPedido pedido);
		DtoComanda TrateInclusaoDeComanda(DtoComanda comanda);
	}
}
