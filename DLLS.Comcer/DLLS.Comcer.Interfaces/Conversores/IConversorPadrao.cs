using System.Collections.Generic;

namespace DLLS.Comcer.Interfaces.Conversores
{
   public interface IConversorPadrao<TObjeto, TDto>
	{
		IList<TDto> Converta(IList<TObjeto> objeto);
		IList<TObjeto> Converta(IList<TDto> objeto);
		TDto Converta(TObjeto objeto);
		TObjeto Converta(TDto objeto);
	}
}
