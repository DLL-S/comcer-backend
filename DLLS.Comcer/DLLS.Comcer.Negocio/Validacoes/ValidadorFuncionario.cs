using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Utilitarios.Globalizacoes;
using FluentValidation;

namespace DLLS.Comcer.Negocio.Validacoes
{
	public class ValidadorFuncionario : ValidadorPadrao<Funcionario>, IValidadorFuncionario
	{
		#region Validações individuais

		#region EMAIL

		private void AssineRegraEmailObrigatorio()
		{
			RuleFor(x => x.Email)
				.NotEmpty()
				.WithMessage(string.Format(Globalizacoes.CampoObrigatorio, "email"));
		}

		private void AssineRegraEmailValido()
		{
			RuleFor(x => x.Email)
				.Must(EmailValido)
				.WithMessage(string.Format(Globalizacoes.CampoValido, "email"));
		}

		#endregion

		#region CPF

		private void AssineRegraCPFObrigatorio()
		{
			RuleFor(x => x.CPF)
				.NotEmpty()
				.WithMessage(string.Format(Globalizacoes.CampoObrigatorio, "CPF"));
		}

		private void AssineRegraCPFValido()
		{
			RuleFor(x => x.CPF)
				.Must(CPFValido)
				.WithMessage(string.Format(Globalizacoes.CampoValido, "CPF"));
		}

		#endregion


		#endregion
		#region Validações agrupadas
		private void AssineRegrasEmail()
		{
			AssineRegraEmailObrigatorio();
			AssineRegraEmailValido();
		}

		private void AssineRegrasCPF()
		{
			AssineRegraCPFObrigatorio();
			AssineRegraCPFValido();
		}

		public override void AssineRegrasComunsCadastroEAtualizacao()
		{
			AssineRegrasEmail();
			AssineRegrasCPF();
		}
		#endregion

		#region Implementação das validaçoes
		private bool EmailValido(string arg)
		{
			return !UtilExtension.UtilsExtension.CheckEmail(arg);
		}

		private bool CPFValido(string arg)
		{
			return !UtilExtension.UtilsExtension.CheckCpf(arg);
		}

		#endregion
	}
}
