using System;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Dominio.Objetos.FuncionarioObj
{
	public class Funcionario : ObjetoComIdNumerico
	{
		public const int TAMANHO_MAXIMO_NOME = 80;
		public const int TAMANHO_MAXIMO_EMAIL = 60;
		public const int TAMANHO_MAXIMO_CPF = 14;
		public const int TAMANHO_MAXIMO_CELULAR = 16;

		public virtual string Nome { get; set; }
		public virtual string CPF { get; set; }
		public virtual DateTime DataNascimento { get; set; }
		public virtual string Email { get; set; }
		public virtual string Celular { get; set; }
		public virtual Endereco Endereco { get; set; }
		public virtual EnumSituacao Situacao { get; set; }
	}
}
