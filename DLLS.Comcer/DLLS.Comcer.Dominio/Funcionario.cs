using System;

namespace DLLS.Comcer.Dominio
{
    public class Funcionario
    {
			public long Id { get; set; }
			public string Nome { get; set; }
			public string CPF { get; set; }
			public DateTime DataNascimento { get; set; }
			public string Email { get; set; }
			public string Celular { get; set; }
			public Endereco Endereco { get; set; }
	}
}
