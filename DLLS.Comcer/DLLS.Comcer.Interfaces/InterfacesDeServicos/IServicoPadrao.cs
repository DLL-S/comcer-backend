using System.Collections.Generic;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoPadrao<TDto> where TDto : DtoBase
	{
		TDto Consulte(long condigo);
		IList<TDto> Liste();
		IList<TDto> Liste(int pagina, int quantidade, EnumOrdem ordem);
		TDto Atualize(TDto objeto);
		TDto Cadastre(TDto objeto);
		void Exclua(long codigo);
	}
}
