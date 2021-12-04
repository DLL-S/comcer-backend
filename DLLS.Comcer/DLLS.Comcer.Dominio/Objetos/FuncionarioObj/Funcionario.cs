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

		public string Nome { get; set; }
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Email { get; set; }
		public string Celular { get; set; }
		public Endereco Endereco { get; set; }
		public EnumSituacao Situacao { get; set; }
	}
}
