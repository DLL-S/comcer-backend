namespace DLLS.Comcer.Dominio.Objetos.Compartilhados
{
	public class Endereco : ObjetoComIdNumerico
	{
		public const int TAMANHO_MAXIMO_CEP = 10;
		public const int TAMANHO_MAXIMO_CIDADE = 30;
		public const int TAMANHO_MAXIMO_ESTADO = 30;
		public const int TAMANHO_MAXIMO_BAIRRO = 60;
		public const int TAMANHO_MAXIMO_RUA = 15;
		public const int TAMANHO_MAXIMO_COMPLEMENTO = 60;

		public string Cep { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Bairro { get; set; }
		public string Rua { get; set; }
		public int Numero { get; set; }
		public string Complemento { get; set; }
	}
}
