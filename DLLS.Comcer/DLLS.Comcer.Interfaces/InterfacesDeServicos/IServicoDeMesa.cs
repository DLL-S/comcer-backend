using System.Collections.Generic;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeMesa : IServicoPadrao<DtoMesa>
	{
		DtoSaida<DtoComanda> ObtenhaComandas(int numeroMesa);
		DtoSaida<DtoMesa> IncluaComanda(int numeroMesa, DtoComanda comanda);
		IList<int> ObtenhaMesasAtivas();
		DtoSaida<DtoComanda> EncerrarComanda(int codigo, bool paraPagamento);
	}
}
