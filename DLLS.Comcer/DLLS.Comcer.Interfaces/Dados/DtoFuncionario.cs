using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLS.Comcer.Interfaces.Dados
{
	public class DtoFuncionario
   {
			public long Id { get; set; }
			public string Nome { get; set; }
			public string CPF { get; set; }
			public DateTime DataNascimento { get; set; }
			public string Email { get; set; }
			public string Celular { get; set; }
			public DtoEndereco Endereco { get; set; }
	}
}
