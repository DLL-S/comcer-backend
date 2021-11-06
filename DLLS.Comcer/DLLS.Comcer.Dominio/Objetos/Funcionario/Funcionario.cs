using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;

namespace DLLS.Comcer.Dominio.Objetos.Funcionario
{
	public class Funcionario : ObjetoComIdNumerico
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Email { get; set; }
		public string Celular { get; set; }
		public Endereco Endereco { get; set; }
	}
}
