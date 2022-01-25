using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDePedido : IServicoPadrao<DtoPedido>
	{
		DtoSaida<DtoPedido> AtualizeStatus(int codigo, EnumStatusPedido statusPedido);
	}
}
