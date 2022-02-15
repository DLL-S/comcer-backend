using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Servicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DLLS.Comcer.UnitTests.Servicos
{
	public abstract class ServicoTestHelper<TDto, TObjeto>
		where TDto : DtoBase
		where TObjeto : ObjetoComIdNumerico
	{
		protected ServicoPadraoImpl<TObjeto, TDto> servico;

		public abstract TDto ObtenhaDto(int codigo = 0);

		public abstract TObjeto ObtenhaObj(int codigo = 0);

		public abstract void AssertDtoEhIgual(TDto esperado, TDto obtido);

		public virtual void AssertListaDtoEhIgual(IList<TDto> esperado, IList<TDto> obtido)
		{
			Assert.AreEqual(esperado.Any(), obtido.Any());
			Assert.AreEqual(esperado.Count, obtido.Count);
			for (int i = 0; i < esperado.Count; i++)
			{
				AssertDtoEhIgual(esperado[i], obtido[i]);
			}
		}

		public virtual void AssertDtoSaidaEhIgual(DtoSaida<TDto> esperado, DtoSaida<TDto> obtido)
		{
			Assert.AreEqual(esperado.Pagina, obtido.Pagina);
			Assert.AreEqual(esperado.Quantidade, obtido.Quantidade);
			Assert.AreEqual(esperado.Sucesso, obtido.Sucesso);
			Assert.AreEqual(esperado.Total, obtido.Total);
			Assert.AreEqual(esperado.Validacoes, obtido.Validacoes);
			AssertListaDtoEhIgual(esperado.Resultados, obtido.Resultados);
		}

		public static void AssertAreEqualByteArray(byte[] esperado, byte[] obtido)
		{
			Assert.AreEqual(esperado.Any(), obtido.Any());
			Assert.AreEqual(esperado.Length, obtido.Length);
			for (int i = 0; i < esperado.Length; i++)
			{
				Assert.AreEqual(esperado[i], obtido[i]);
			}
		}

		public static DtoSaida<Tdto> EncapsuleDto<Tdto>(Tdto dto, bool sucesso) where Tdto : DtoBase
		{
			return new DtoSaida<Tdto> {
				Quantidade = ConstantesTestes.INT,
				Resultados = new List<Tdto> { dto },
				Pagina = 0,
				Sucesso = sucesso,
				Total = 0
			};
		}
	}
}
