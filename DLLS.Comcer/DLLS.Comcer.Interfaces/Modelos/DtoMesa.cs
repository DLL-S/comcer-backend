using System.Collections.Generic;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoMesa : DtoBase
	{
		public int Numero { get; set; }
		public IList<DtoComanda> Comandas { get; set; }
		public bool Disponivel { get; set; }
	}
}
