using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeConversores
{
	public interface IConversorProduto : IConversorPadrao<Produto, DtoProduto>
	{
	}
}
