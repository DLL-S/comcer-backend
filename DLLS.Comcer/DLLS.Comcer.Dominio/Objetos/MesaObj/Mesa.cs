using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;

namespace DLLS.Comcer.Dominio.Objetos.MesaObj
{
	public class Mesa : ObjetoComIdNumerico
	{
		public virtual int Numero { get; set; }
		public virtual IList<Comanda> Comandas { get; set; }
		public virtual bool Disponivel { get; set; }
	}
}
