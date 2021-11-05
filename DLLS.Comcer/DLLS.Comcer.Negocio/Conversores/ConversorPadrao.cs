using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using DLLS.Comcer.Interfaces.Conversores;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorPadrao<TObjeto, TDto> : IConversorPadrao<TObjeto, TDto>
	{
		public TDto Converta(TObjeto objeto)
		{
			return Copie<TDto, TObjeto>(objeto);
		}

		public TObjeto Converta(TDto objeto)
		{
			return Copie<TObjeto, TDto>(objeto);
		}

		public IList<TDto> Converta(IList<TObjeto> objeto)
		{
			var lista = new List<TDto>();

			Parallel.ForEach(objeto, item => lista.Add(Converta(item)));

			return lista;
		}

		public IList<TObjeto> Converta(IList<TDto> objeto)
		{
			var lista = new List<TObjeto>();

			Parallel.ForEach(objeto, item => lista.Add(Converta(item)));

			return lista;
		}

		private static TSaida Copie<TSaida, TEntrada>(TEntrada entrada)
		{
			Type typeT = typeof(TEntrada);
			PropertyInfo[] propertyEntrada = typeT.GetProperties();
			TSaida saida = (TSaida)Activator.CreateInstance(typeof(TSaida));
			foreach (var propEntrada in propertyEntrada)
			{
				var nomePropEntrada = propEntrada.Name;
				var valorPropEntrada = propEntrada.GetValue(entrada, null);

				Type tipoSaida = typeof(TSaida);
				PropertyInfo[] propertySaida = tipoSaida.GetProperties();
				foreach (var propSaida in propertySaida)
				{
					var nomePropSaida = propSaida.Name;
					if (nomePropEntrada == nomePropSaida)
					{
						propSaida.SetValue(saida, valorPropEntrada);
						break;
					}
				}
			}

			return saida;
		}

	}
}
