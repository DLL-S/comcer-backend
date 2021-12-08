using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorPadrao<TObjeto, TDto> : IConversorPadrao<TObjeto, TDto>
		where TDto : DtoBase
		where TObjeto : ObjetoComIdNumerico
	{
		public virtual TDto Converta(TObjeto objeto)
		{
			if (objeto == null)
			{
				return (TDto)Activator.CreateInstance(typeof(TDto));
			}

			var dto = Copie<TDto, TObjeto>(objeto);

			return dto;
		}

		public virtual TObjeto Converta(TDto dto)
		{
			if (dto == null)
			{
				return (TObjeto)Activator.CreateInstance(typeof(TObjeto));
			}

			return Copie<TObjeto, TDto>(dto);
		}

		public virtual DtoSaida<TDto> ConvertaParaDtoSaida(TDto dto)
		{
			var dtoSaida = new DtoSaida<TDto> {
				Resultados = new List<TDto> { dto }
			};

			dtoSaida.Quantidade = dtoSaida.Resultados.Count;

			return dtoSaida;
		}

		public virtual DtoSaida<TDto> ConvertaParaDtoSaida(TObjeto objeto)
		{
			var dtoConvertido = Converta(objeto);
			return ConvertaParaDtoSaida(dtoConvertido);
		}

		public virtual DtoSaida<TDto> ConvertaParaDtoSaida(IList<TDto> dto)
		{
			var dtoSaida = new DtoSaida<TDto> {
				Resultados = dto
			};

			dtoSaida.Quantidade = dtoSaida.Resultados.Count;

			return dtoSaida;
		}

		public virtual DtoSaida<TDto> ConvertaParaDtoSaida(IList<TObjeto> objeto)
		{
			var dtoConvertido = Converta(objeto);
			return ConvertaParaDtoSaida(dtoConvertido);
		}

		public virtual IList<TDto> Converta(IList<TObjeto> objeto)
		{
			var lista = new List<TDto>();

			if (objeto == null || objeto.Count == 0)
			{
				return lista;
			}

			foreach (var item in objeto)
			{
				lista.Add(Converta(item));
			};

			return lista;
		}

		public virtual IList<TObjeto> Converta(IList<TDto> objeto)
		{
			var lista = new List<TObjeto>();

			if (objeto == null || objeto.Count == 0)
			{
				return lista;
			}

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
						try
						{
							propSaida.SetValue(saida, valorPropEntrada);
							break;
						}
						catch
						{
							// não dá erro quando for tipo diferente.
						}
					}
				}
			}

			return saida;
		}

	}
}
