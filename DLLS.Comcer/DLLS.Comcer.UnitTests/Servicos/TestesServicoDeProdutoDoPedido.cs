using System;
using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Servicos;
using DLLS.Comcer.Utilitarios.Enumeradores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DLLS.Comcer.UnitTests.Servicos
{
	[TestClass]
	public class TestesServicoDeProdutoDoPedido : ServicoTestHelper<DtoProdutoDoPedido, ProdutoDoPedido>
	{
		private static Mock<IRepositorioProdutoDoPedido> repository;
		private static Mock<IConversorProdutoDoPedido> conversor;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			repository = new Mock<IRepositorioProdutoDoPedido>();
			conversor = new Mock<IConversorProdutoDoPedido>();
		}

		[TestMethod]
		public void TestaCadastreProdutoDoPedido()
		{
			repository.Setup(X => X.Cadastre(It.IsAny<ProdutoDoPedido>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeProdutosDoPedidoImpl(repository.Object);
			DtoSaida<DtoProdutoDoPedido> esperado = EncapsuleDto(ObtenhaDto(1), true);
			DtoSaida<DtoProdutoDoPedido> retorno = servico.Cadastre(ObtenhaDto());
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaConsulteProdutoDoPedido()
		{
			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(ObtenhaObj(1));
			conversor.Setup(x => x.Converta(It.IsAny<ProdutoDoPedido>())).Returns(ObtenhaDto(1));
			servico = new ServicoDeProdutosDoPedidoImpl(repository.Object);
			DtoSaida<DtoProdutoDoPedido> retorno = servico.Consulte(1);
			DtoSaida<DtoProdutoDoPedido> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaListeProdutoDoPedido()
		{
			repository.Setup(X => X.Liste(1, 1, EnumOrdem.ASC, null)).Returns(new List<ProdutoDoPedido> { ObtenhaObj(1) });
			conversor.Setup(x => x.Converta(It.IsAny<ProdutoDoPedido>())).Returns(ObtenhaDto(1));
			servico = new ServicoDeProdutosDoPedidoImpl(repository.Object);
			DtoSaida<DtoProdutoDoPedido> retorno = servico.Liste(1, 1, EnumOrdem.ASC, null);
			DtoSaida<DtoProdutoDoPedido> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaAtualizeProdutoDoPedido()
		{
			repository.Setup(X => X.Atualize(It.IsAny<ProdutoDoPedido>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeProdutosDoPedidoImpl(repository.Object);
			DtoSaida<DtoProdutoDoPedido> retorno = servico.Atualize(ObtenhaDto(1));
			DtoSaida<DtoProdutoDoPedido> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaAtualizeStatusDoPedido()
		{
			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(ObtenhaObj(1));
			var auxEnvio = ObtenhaObj(1);
			auxEnvio.Status = EnumStatusPedido.PENDENTE;
			repository.Setup(X => X.Atualize(It.IsAny<ProdutoDoPedido>())).Returns(auxEnvio);
			servico = new ServicoDeProdutosDoPedidoImpl(repository.Object);
			DtoSaida<DtoProdutoDoPedido> retorno = ((ServicoDeProdutosDoPedidoImpl)servico).AtualizeStatus(1, EnumStatusPedido.PENDENTE);
			var auxEsperado = ObtenhaDto(1);
			auxEsperado.Status = EnumStatusPedido.PENDENTE;
			DtoSaida<DtoProdutoDoPedido> esperado = EncapsuleDto(auxEsperado, true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void TestaExcluaProdutoDoPedido(bool sucesso)
		{
			if (sucesso)
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>()));
				servico = new ServicoDeProdutosDoPedidoImpl(repository.Object);
				servico.Exclua(1);
			}
			else
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>())).Throws(new Exception());
				servico = new ServicoDeProdutosDoPedidoImpl(repository.Object);
				Assert.ThrowsException<Exception>(() => servico.Exclua(1));
			}
		}

		public override DtoProdutoDoPedido ObtenhaDto(int codigo = 0)
		{
			return new DtoProdutoDoPedido {
				DataHoraPedido = ConstantesTestes.DATA,
				Id = ConstantesTestes.INT,
				Quantidade = ConstantesTestes.INT,
				Status = EnumStatusPedido.COZINHANDO,
				ValorUnitario = ConstantesTestes.DECIMAL
			};
		}

		public override ProdutoDoPedido ObtenhaObj(int codigo = 0)
		{
			return new ProdutoDoPedido {
				DataHoraPedido = ConstantesTestes.DATA,
				Id = ConstantesTestes.INT,
				Quantidade = ConstantesTestes.INT,
				Status = EnumStatusPedido.COZINHANDO,
				ValorUnitario = ConstantesTestes.DECIMAL
			};
		}

		public override void AssertDtoEhIgual(DtoProdutoDoPedido esperado, DtoProdutoDoPedido obtido)
		{
			Assert.AreEqual(esperado.DataHoraPedido, obtido.DataHoraPedido);
			Assert.AreEqual(esperado.Id, obtido.Id);
			Assert.AreEqual(esperado.Quantidade, obtido.Quantidade);
			Assert.AreEqual(esperado.Status, obtido.Status);
			Assert.AreEqual(esperado.ValorUnitario, obtido.ValorUnitario);
			if (esperado.Produto != null)
			{
				Assert.AreEqual(esperado.Produto.Id, obtido.Produto.Id);
				Assert.AreEqual(esperado.Produto.Descricao, obtido.Produto.Descricao);
				Assert.AreEqual(esperado.Produto.Foto, obtido.Produto.Foto);
				Assert.AreEqual(esperado.Produto.Nome, obtido.Produto.Nome);
				Assert.AreEqual(esperado.Produto.Preco, obtido.Produto.Preco);
			}
		}
	}
}
