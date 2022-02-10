using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorComanda : ConversorPadrao<Comanda, DtoComanda>, IConversorComanda
	{
		ConversorPedido conversorPedido;

		public override DtoComanda Converta(Comanda objeto)
		{
			DtoComanda dto = base.Converta(objeto);
			dto.ListaPedidos = ConversorPedido().Converta(objeto.ListaPedidos);

			return dto;
		}

		public override Comanda Converta(DtoComanda dto)
		{
			Comanda objeto = base.Converta(dto);
			objeto.ListaPedidos = ConversorPedido().Converta(dto.ListaPedidos);
			return objeto;
		}

		private ConversorPedido ConversorPedido()
		{
			return conversorPedido ??= new ConversorPedido();
		}
	}
}
