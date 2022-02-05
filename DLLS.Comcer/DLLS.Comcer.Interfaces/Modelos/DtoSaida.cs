using System.Collections.Generic;
using DLLS.Comcer.Utilitarios.Utils;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoSaida<TDto> where TDto : DtoBase
	{
		public DtoSaida()
		{
			Sucesso = true;
		}

		public IList<TDto> Resultados { get; set; }

		public IList<InconsistenciaDeValidacao> Validacoes { get; set; }

		public bool Sucesso { get; set; }

		public int Pagina { get; set; }

		public int Quantidade { get; set; }

		public int Total { get; set; }
	}
}
