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

		private void AssineRegraCodigoObrigatorio()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage(string.Format(Globalizacoes.CampoObrigatorio, "ID"));
		}

		private void AssineRegraCodigoValido()
		{
			RuleFor(x => x.Id)
				.Must(CodigoValido)
				.WithMessage(string.Format(Globalizacoes.CampoTamanhoRange, "ID", 1, ObjetoComIdNumerico.TAMANHO_MAXIMO_CODIGO));
		}

		#endregion

		#endregion

		#region AGRUPAMENTOS DE VALIDACOES

		public virtual void AssineRegrasCodigo()
		{
			AssineRegraCodigoObrigatorio();
			AssineRegraCodigoValido();
		}

		public virtual void AssineRegrasAtualizacao()
		{
			AssineRegrasCodigo();
		}

		public abstract void AssineRegrasCadastro();

		public virtual void AssineRegrasExclusao()
		{
			AssineRegrasCodigo();
		}

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
			return codigo != 0 && codigo <= ObjetoComIdNumerico.TAMANHO_MAXIMO_CODIGO;
		}

		#endregion
	}
}
