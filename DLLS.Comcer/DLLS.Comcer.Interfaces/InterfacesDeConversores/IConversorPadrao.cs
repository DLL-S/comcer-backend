using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeConversores
{
	public interface IConversorPadrao<TObjeto, TDto>
		where TDto : DtoBase
		where TObjeto : ObjetoComIdNumerico
	{
		TDto Converta(TObjeto objeto);
		TObjeto Converta(TDto dtos);
		IList<TDto> Converta(IList<TObjeto> objetos);
		IList<TObjeto> Converta(IList<TDto> dtos);
		DtoSaida<TDto> ConvertaParaDtoSaida(TDto dto);
		DtoSaida<TDto> ConvertaParaDtoSaida(IList<TDto> dtos);
		DtoSaida<TDto> ConvertaParaDtoSaida(TObjeto objeto);
		DtoSaida<TDto> ConvertaParaDtoSaida(IList<TObjeto> objetos);
	}
}
