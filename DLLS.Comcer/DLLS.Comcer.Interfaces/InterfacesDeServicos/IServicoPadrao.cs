using System.Collections.Generic;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoPadrao<TDto> where TDto : DtoBase
	{
		TDto Consulte(long condigo);
		IList<TDto> Liste();
		TDto Atualize(TDto objeto);
		TDto Cadastre(TDto objeto);
		void Exclua(long condigo);
	}
}
