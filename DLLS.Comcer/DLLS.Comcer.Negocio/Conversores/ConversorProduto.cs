using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorProduto : ConversorPadrao<Produto, DtoProduto>, IConversorProduto
	{
	}
}
