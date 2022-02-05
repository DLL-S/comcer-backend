using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Utilitarios.Utils;

namespace DLLS.Comcer.Interfaces.InterfacesDeValidacao
{
	public interface IValidadorPadrao<TObjeto>
		where TObjeto : ObjetoComIdNumerico
	{
		void AssineRegrasCadastro();

		void AssineRegrasAtualizacao();

		void AssineRegrasExclusao();

		abstract IList<InconsistenciaDeValidacao> Valide(TObjeto objeto);
	}
}
