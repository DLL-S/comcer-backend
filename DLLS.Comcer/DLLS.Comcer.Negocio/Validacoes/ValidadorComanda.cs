using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;

namespace DLLS.Comcer.Negocio.Validacoes
{
	public class ValidadorComanda : ValidadorPadrao<Comanda>, IValidadorComanda
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
