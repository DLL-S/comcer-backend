using System.Collections.Generic;

namespace DLLS.Comcer.Interfaces.Modelos
{
   public class DtoBase
	{
		public long Id { get; set; }

		public IList<MensagemDeValidacao> Validacoes { get; set; }

		public bool Sucesso { get; set; }
	}
}
