using DLLS.Comcer.Dominio.Objetos.Compartilhados;

namespace DLLS.Comcer.Dominio.Objetos.ProdutoObj
{
	public class Produto : ObjetoComIdNumerico
	{
		public const int TAMANHO_MAXIMO_NOME = 80;
		public const int TAMANHO_MAXIMO_DESCRICAO = 255;

		/// <summary>
		/// 100 Kbytes
		/// </summary>
		public const int TAMANHO_MAXIMO_FOTO = 1024000;

		public virtual string Nome { get; set; }

		public string Descricao { get; set; }

		public decimal Preco { get; set; }

		public byte[] Foto { get; set; }
	}
}
