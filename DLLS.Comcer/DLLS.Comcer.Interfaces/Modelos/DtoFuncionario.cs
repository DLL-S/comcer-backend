using System;

namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoFuncionario : DtoBase
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Email { get; set; }
		public string Celular { get; set; }
		public DtoEndereco Endereco { get; set; }
	}
}
