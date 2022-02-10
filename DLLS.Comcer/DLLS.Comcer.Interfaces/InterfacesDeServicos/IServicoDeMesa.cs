using System.Collections.Generic;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeMesa : IServicoPadrao<DtoMesa>
	{
		DtoSaida<DtoComanda> ObtenhaComandas(int NumeroMesa);
		DtoSaida<DtoMesa> IncluaComanda(int NumeroMesa, DtoComanda comanda);
		IList<int> ObtenhaMesasAtivas();
	}
}
