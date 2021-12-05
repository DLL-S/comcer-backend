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

		public virtual string Cep { get; set; }
		public virtual string Cidade { get; set; }
		public virtual string Estado { get; set; }
		public virtual string Bairro { get; set; }
		public virtual string Rua { get; set; }
		public virtual int Numero { get; set; }
		public virtual string Complemento { get; set; }
	}
}
