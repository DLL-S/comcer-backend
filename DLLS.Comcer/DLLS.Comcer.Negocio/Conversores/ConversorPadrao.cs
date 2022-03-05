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

			TDto dto = Copie<TDto, TObjeto>(objeto);

			return dto;
		}

		public virtual TObjeto Converta(TDto dtos)
		{
			if (dtos == null)
			{
				return (TObjeto)Activator.CreateInstance(typeof(TObjeto));
			}

			return Copie<TObjeto, TDto>(dtos);
		}

		public virtual IList<TDto> Converta(IList<TObjeto> objetos)
		{
			var lista = new List<TDto>();

			if (objetos == null || objetos.Count == 0)
			{
				return lista;
			}

			foreach (TObjeto item in objetos)
			{
				lista.Add(Converta(item));
			}

			return lista;
		}

		public virtual IList<TObjeto> Converta(IList<TDto> dtos)
		{
			var lista = new List<TObjeto>();

			if (dtos == null || dtos.Count == 0)
			{
				return lista;
			}

			Parallel.ForEach(dtos, item => lista.Add(Converta(item)));

			return lista;
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
			TDto dtoConvertido = Converta(objeto);
			return ConvertaParaDtoSaida(dtoConvertido);
		}

		public virtual DtoSaida<TDto> ConvertaParaDtoSaida(IList<TDto> dtos)
		{
			var dtoSaida = new DtoSaida<TDto> {
				Resultados = dtos
			};

			dtoSaida.Quantidade = dtoSaida.Resultados.Count;

			return dtoSaida;
		}

		public virtual DtoSaida<TDto> ConvertaParaDtoSaida(IList<TObjeto> objetos)
		{
			IList<TDto> dtoConvertido = Converta(objetos);
			return ConvertaParaDtoSaida(dtoConvertido);
		}

		protected static TSaida Copie<TSaida, TEntrada>(TEntrada entrada)
		{
			Type typeT = typeof(TEntrada);
			PropertyInfo[] propertyEntrada = typeT.GetProperties();
			var saida = (TSaida)Activator.CreateInstance(typeof(TSaida));
			foreach (PropertyInfo propEntrada in propertyEntrada)
			{
				string nomePropEntrada = propEntrada.Name;
				object valorPropEntrada = propEntrada.GetValue(entrada, null);

				Type tipoSaida = typeof(TSaida);
				PropertyInfo[] propertySaida = tipoSaida.GetProperties();
				foreach (PropertyInfo propSaida in propertySaida)
				{
					string nomePropSaida = propSaida.Name;
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
