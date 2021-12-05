using System.Collections.Generic;
using DLLS.Comcer.Dominio.Modelos;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using FluentValidation;

namespace DLLS.Comcer.Dominio
{
	public abstract class ValidadorPadrao<TObjeto> : AbstractValidator<TObjeto> where TObjeto : ObjetoComIdNumerico
	{
		public IList<MensagemDeValidacao> Valide(ValidationContext<TObjeto> context)
		{
			var resultadoValidacao = base.Validate(context);

			var listaRetorno = new List<MensagemDeValidacao>();

			foreach (var erro in resultadoValidacao.Errors)
			{
				var itemAdd = new MensagemDeValidacao();
				itemAdd.Mensagem = erro.ErrorMessage;
				itemAdd.Propriedade = erro.PropertyName;
				itemAdd.Impeditivo = erro.Severity.Equals(Severity.Error);
			}

			return listaRetorno;
		}
	}
}
