using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;

namespace DLLS.Comcer.Negocio.Validacoes
{
	public class ValidadorProdutoDoPedido : ValidadorPadrao<ProdutoDoPedido>, IValidadorProdutoDoPedido
	{
		#region Validações individuais

		#endregion

		#region Validações agrupadas
		public override void AssineRegrasComunsCadastroEAtualizacao()
		{
		}
		#endregion

		#region Implementação das validaçoes
		#endregion
	}
}
