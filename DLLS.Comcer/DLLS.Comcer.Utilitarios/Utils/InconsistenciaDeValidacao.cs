namespace DLLS.Comcer.Utilitarios.Utils
{
	/// <summary>
	/// Classe para inconsistência de validação de objetos.
	/// </summary>
	public class InconsistenciaDeValidacao
	{
		public InconsistenciaDeValidacao()
		{ }

		public InconsistenciaDeValidacao(string propriedade, string mensagem, bool impeditivo)
		{
			Propriedade = propriedade;
			Mensagem = mensagem;
			Impeditivo = impeditivo;
		}

		/// <summary>
		/// Nome da propriedade inconsistente.
		/// </summary>
		public virtual string Propriedade { get; set; }

		/// <summary>
		/// Mensagem de inconsistência.
		/// </summary>
		public virtual string Mensagem { get; set; }

		/// <summary>
		/// Indica se a inconsistência é impeditiva ou apenas aviso.
		/// </summary>
		public virtual bool Impeditivo { get; set; }
	}
}
