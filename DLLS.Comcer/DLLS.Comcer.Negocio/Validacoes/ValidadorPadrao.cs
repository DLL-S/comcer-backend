using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Utilitarios.Globalizacoes;
using DLLS.Comcer.Utilitarios.Utils;
using FluentValidation;

namespace DLLS.Comcer.Negocio.Validacoes
{
	public abstract class ValidadorPadrao<TObjeto> : AbstractValidator<TObjeto>, IValidadorPadrao<TObjeto>
		where TObjeto : ObjetoComIdNumerico
	{
		#region VALIDACOES DE PROPRIEDADES

		#region CODIGO

		public void AssineRegraCodigoObrigatorio()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage(string.Format(Globalizacoes.CampoObrigatorio, "ID"));
		}

		public void AssineRegraCodigoValido()
		{
			RuleFor(x => x.Id)
				.Must(CodigoValido)
				.WithMessage(string.Format(Globalizacoes.CampoObrigatorio, "ID"));
		}

		#endregion

		#endregion

		#region AGRUPAMENTOS DE VALIDACOES

		public abstract void AssineRegrasAtualizacao();

		public abstract void AssineRegrasCadastro();

		public abstract void AssineRegrasExclusao();

		#endregion

		public IList<InconsistenciaDeValidacao> Valide(TObjeto objeto)
		{
			var resultadoValidacao = Validate(objeto);

			var listaRetorno = new List<InconsistenciaDeValidacao>();

			foreach (var erro in resultadoValidacao.Errors)
			{
				var itemAdd = new InconsistenciaDeValidacao();
				itemAdd.Mensagem = erro.ErrorMessage;
				itemAdd.Propriedade = erro.PropertyName;
				itemAdd.Impeditivo = erro.Severity.Equals(Severity.Error);
			}

			return listaRetorno;
		}

		#region MÉTODOS PRIVADOS

		private bool CodigoValido(int codigo)
		{
			return codigo != 0 && codigo.ToString().Length <= ObjetoComIdNumerico.TAMANHO_MAXIMO_CODIGO;
		}

		#endregion
	}
}
