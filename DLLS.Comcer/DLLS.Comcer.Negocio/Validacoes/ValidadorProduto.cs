using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;

namespace DLLS.Comcer.Negocio.Validacoes
{
	public class ValidadorProduto : ValidadorPadrao<Produto>, IValidadorProduto
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
