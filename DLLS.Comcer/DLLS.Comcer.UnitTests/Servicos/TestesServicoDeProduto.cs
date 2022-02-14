using System;
using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Servicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DLLS.Comcer.UnitTests.Servicos
{
	[TestClass]
	public class TestesServicoDeProduto : ServicoTestHelper<DtoProduto, Produto>
	{
		private static Mock<IRepositorioProduto> repository;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			repository = new Mock<IRepositorioProduto>();
		}

		[TestMethod]
		public void TestaCadastreProduto()
		{
			repository.Setup(X => X.Cadastre(It.IsAny<Produto>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeProdutoImpl(repository.Object);
			DtoSaida<DtoProduto> esperado = EncapsuleDto(ObtenhaDto(1), true);
			DtoSaida<DtoProduto> retorno = servico.Cadastre(ObtenhaDto());
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaConsulteProduto()
		{
			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeProdutoImpl(repository.Object);
			DtoSaida<DtoProduto> retorno = servico.Consulte(1);
			DtoSaida<DtoProduto> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaAtualizeProduto()
		{
			repository.Setup(X => X.Atualize(It.IsAny<Produto>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeProdutoImpl(repository.Object);
			DtoSaida<DtoProduto> retorno = servico.Atualize(ObtenhaDto(1));
			DtoSaida<DtoProduto> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void TestaExcluaProduto(bool sucesso)
		{
			if (sucesso)
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>()));
				servico = new ServicoDeProdutoImpl(repository.Object);
				servico.Exclua(1);
			}
			else
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>())).Throws(new Exception());
				servico = new ServicoDeProdutoImpl(repository.Object);
				Assert.ThrowsException<Exception>(() => servico.Exclua(1));
			}
		}

		protected override DtoProduto ObtenhaDto(int codigo = 0)
		{
			return new DtoProduto {
				Id = codigo,
				Descricao = ConstantesTestes.STRING,
				Nome = ConstantesTestes.STRING,
				Foto = ConstantesTestes.BYTE_ARRAY,
				Preco = ConstantesTestes.DECIMAL
			};
		}

		protected override Produto ObtenhaObj(int codigo = 0)
		{
			return new Produto {
				Id = codigo,
				Descricao = ConstantesTestes.STRING,
				Nome = ConstantesTestes.STRING,
				Foto = ConstantesTestes.BYTE_ARRAY,
				Preco = ConstantesTestes.DECIMAL
			};
		}

		protected override void AssertDtoEhIgual(DtoProduto esperado, DtoProduto obtido)
		{
			Assert.AreEqual(esperado.Descricao, obtido.Descricao);
			Assert.AreEqual(esperado.Preco, obtido.Preco);
			Assert.AreEqual(esperado.Id, obtido.Id);
			Assert.AreEqual(esperado.Nome, obtido.Nome);
			AssertAreEqualByteArray(esperado.Foto, obtido.Foto);
		}
	}
}
