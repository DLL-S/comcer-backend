﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLS.Comcer.Dominio.Objetos.Compartilhados
{
	public class Endereco : ObjetoComIdNumerico
	{
		public string Cep { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Bairro { get; set; }
		public string Rua { get; set; }
		public int Numero { get; set; }
		public string Complemento { get; set; }
	}
}
