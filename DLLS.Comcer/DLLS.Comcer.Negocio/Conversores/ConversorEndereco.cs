using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorEndereco : ConversorPadrao<Endereco, DtoEndereco>, IConversorEndereco
	{
	}
}
