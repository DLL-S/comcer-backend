namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoProduto : DtoBase
	{
		public string Nome { get; set; }

		public string Descricao { get; set; }

		public decimal Preco { get; set; }

		public byte[] Foto { get; set; }
	}
}
