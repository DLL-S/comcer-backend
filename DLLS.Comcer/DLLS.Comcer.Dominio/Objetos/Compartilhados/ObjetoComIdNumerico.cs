using System;
using System.Linq.Expressions;

namespace DLLS.Comcer.Dominio.Objetos.Compartilhados
{
	public class ObjetoComIdNumerico : IComparable
	{
		public const int TAMANHO_MAXIMO_CODIGO = 999999;

		public virtual int Id { get; set; }

		public virtual int CompareTo(object obj)
		{
			ObjetoComIdNumerico Temp = (ObjetoComIdNumerico)obj;
			if (this.Id < Temp.Id)
				return 1;
			if (this.Id > Temp.Id)
				return -1;
			else
				return 0;
		}
	}
}
