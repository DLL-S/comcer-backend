using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeConversores
{
	public interface IConversorComanda : IConversorPadrao<Comanda, DtoComanda>
	{
	}
}
