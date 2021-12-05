using System.Collections.Generic;
using DLLS.Comcer.Dominio.Modelos;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public abstract class DtoBase
	{
		public int Id { get; set; }

		public IList<MensagemDeValidacao> Validacoes { get; set; }

		public bool Sucesso { get; set; }
	}
}
