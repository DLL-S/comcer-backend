using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Utils;

namespace DLLS.Comcer.Negocio.Validacoes
{
	public static class CentralDeValidacoes<TDto> where TDto : DtoBase
	{
		public static void Valide<TDtoTipo, TObjeto>(
			ref TDtoTipo dto,
			TObjeto objetoAValidar,
			IValidadorPadrao<TObjeto> validador)
		where TDtoTipo : DtoSaida<TDto>
		where TObjeto : ObjetoComIdNumerico
		{
			IList<InconsistenciaDeValidacao> retornoValidacao = validador.Valide(objetoAValidar);

			if (retornoValidacao.Any(x => x.Impeditivo))
			{
				dto.Sucesso = false;
			}

			foreach (InconsistenciaDeValidacao item in retornoValidacao)
			{
				dto.Validacoes ??= new List<InconsistenciaDeValidacao>();
				dto.Validacoes.Add(new InconsistenciaDeValidacao(item.Propriedade, item.Mensagem, item.Impeditivo));
			}
		}
	}
}
