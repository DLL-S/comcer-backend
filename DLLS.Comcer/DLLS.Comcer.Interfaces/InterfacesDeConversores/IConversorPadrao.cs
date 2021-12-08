using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeConversores
{
	public interface IConversorPadrao<TObjeto, TDto>
		where TDto : DtoBase
		where TObjeto : ObjetoComIdNumerico
	{
		IList<TDto> Converta(IList<TObjeto> objeto);
		IList<TObjeto> Converta(IList<TDto> objeto);
		DtoSaida<TDto> ConvertaParaDtoSaida(TDto dto);
		DtoSaida<TDto> ConvertaParaDtoSaida(IList<TDto> dto);
		DtoSaida<TDto> ConvertaParaDtoSaida(TObjeto objeto);
		DtoSaida<TDto> ConvertaParaDtoSaida(IList<TObjeto> objeto);
		TDto Converta(TObjeto objeto);
		TObjeto Converta(TDto objeto);
	}
}
