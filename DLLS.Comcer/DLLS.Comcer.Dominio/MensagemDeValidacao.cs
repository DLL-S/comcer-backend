namespace DLLS.Comcer.Dominio.Modelos
{
	public class MensagemDeValidacao
	{
		public MensagemDeValidacao()
		{
		}

		public MensagemDeValidacao(string propriedade, string mensagem, bool impeditivo)
		{
			Propriedade = propriedade;
			Mensagem = mensagem;
			Impeditivo = impeditivo;
		}

		public string Propriedade { get; set; }
		public string Mensagem { get; set; }
		public bool Impeditivo { get; set; }
	}
}
