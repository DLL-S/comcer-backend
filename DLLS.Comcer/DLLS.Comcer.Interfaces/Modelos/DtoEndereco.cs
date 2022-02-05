namespace DLLS.Comcer.Interfaces.Modelos
{
	public class DtoEndereco : DtoBase
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
