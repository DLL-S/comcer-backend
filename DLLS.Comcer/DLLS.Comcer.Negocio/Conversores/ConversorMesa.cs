using DLLS.Comcer.Dominio.Objetos.MesaObj;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorMesa : ConversorPadrao<Mesa, DtoMesa>, IConversorMesa
	{
		ConversorComanda conversorComanda;

		public override DtoMesa Converta(Mesa objeto)
		{
			var dto = base.Converta(objeto);
			dto.Comandas = ConversorComanda().Converta(objeto.Comandas);

			return dto;
		}

		public override Mesa Converta(DtoMesa dto)
		{
			var objeto = base.Converta(dto);
			objeto.Comandas = ConversorComanda().Converta(dto.Comandas);
			return objeto;
		}

		private ConversorComanda ConversorComanda()
		{
			return conversorComanda ??= new ConversorComanda();
		}
	}
}
