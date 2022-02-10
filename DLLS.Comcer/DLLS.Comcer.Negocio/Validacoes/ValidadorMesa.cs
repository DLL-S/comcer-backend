using DLLS.Comcer.Dominio.Objetos.MesaObj;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;

namespace DLLS.Comcer.Negocio.Validacoes
{
	public class ValidadorMesa : ValidadorPadrao<Mesa>, IValidadorMesa
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
