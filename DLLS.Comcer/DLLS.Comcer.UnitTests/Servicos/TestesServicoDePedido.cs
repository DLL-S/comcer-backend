using System;
using System.Collections.Generic;
using System.Linq;
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
	public class TestesServicoDePedido : ServicoTestHelper<DtoPedido, Pedido>
	{
		private static Mock<IRepositorioPedido> repository;
		private static Mock<IConversorPedido> conversor;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			repository = new Mock<IRepositorioPedido>();
			conversor = new Mock<IConversorPedido>();
		}

		[TestMethod]
		public void TestaCadastrePedido()
		{
			repository.Setup(X => X.Cadastre(It.IsAny<Pedido>())).Returns(ObtenhaObj(1));
			servico = new ServicoDePedidoImpl(repository.Object);
			DtoSaida<DtoPedido> esperado = EncapsuleDto(ObtenhaDto(1), true);
			DtoSaida<DtoPedido> retorno = servico.Cadastre(ObtenhaDto());
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaConsultePedido()
		{
			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(ObtenhaObj(1));
			conversor.Setup(x => x.Converta(It.IsAny<Pedido>())).Returns(ObtenhaDto(1));
			servico = new ServicoDePedidoImpl(repository.Object);
			DtoSaida<DtoPedido> retorno = servico.Consulte(1);
			DtoSaida<DtoPedido> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaListePedido()
		{
			repository.Setup(X => X.Liste(1, 1, EnumOrdem.ASC, null)).Returns(new List<Pedido> { ObtenhaObj(1) });
			conversor.Setup(x => x.Converta(It.IsAny<Pedido>())).Returns(ObtenhaDto(1));
			servico = new ServicoDePedidoImpl(repository.Object);
			DtoSaida<DtoPedido> retorno = servico.Liste(1, 1, EnumOrdem.ASC, null);
			DtoSaida<DtoPedido> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaAtualizePedido()
		{
			repository.Setup(X => X.Atualize(It.IsAny<Pedido>())).Returns(ObtenhaObj(1));
			servico = new ServicoDePedidoImpl(repository.Object);
			DtoSaida<DtoPedido> retorno = servico.Atualize(ObtenhaDto(1));
			DtoSaida<DtoPedido> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void TestaExcluaPedido(bool sucesso)
		{
			if (sucesso)
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>()));
				servico = new ServicoDePedidoImpl(repository.Object);
				servico.Exclua(1);
			}
			else
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>())).Throws(new Exception());
				servico = new ServicoDePedidoImpl(repository.Object);
				Assert.ThrowsException<Exception>(() => servico.Exclua(1));
			}
		}

		public override DtoPedido ObtenhaDto(int codigo = 0)
		{
			return new DtoPedido {
				Id = codigo,
				DataHoraPedido = ConstantesTestes.DATA,
				ProdutosDoPedido = new List<DtoProdutoDoPedido> {
					new DtoProdutoDoPedido {
						DataHoraPedido = ConstantesTestes.DATA,
						Id = ConstantesTestes.INT,
						Quantidade = ConstantesTestes.INT,
						Status = EnumStatusPedido.COZINHANDO,
						ValorUnitario = ConstantesTestes.DECIMAL
					}
				}
			};
		}

		public override Pedido ObtenhaObj(int codigo = 0)
		{
			return new Pedido {
				Id = codigo,
				DataHoraPedido = ConstantesTestes.DATA,
				ProdutosDoPedido = new List<ProdutoDoPedido> {
					new ProdutoDoPedido {
						DataHoraPedido = ConstantesTestes.DATA,
						Id = ConstantesTestes.INT,
						Quantidade = ConstantesTestes.INT,
						Status = EnumStatusPedido.COZINHANDO,
						ValorUnitario = ConstantesTestes.DECIMAL,
					}
				}
			};
		}

		public override void AssertDtoEhIgual(DtoPedido esperado, DtoPedido obtido)
		{
			Assert.AreEqual(esperado.Id, obtido.Id);
			Assert.AreEqual(esperado.DataHoraPedido, obtido.DataHoraPedido);

			Assert.AreEqual(esperado.ProdutosDoPedido.Any(), obtido.ProdutosDoPedido.Any());
			Assert.AreEqual(esperado.ProdutosDoPedido.Count, obtido.ProdutosDoPedido.Count);
			for (int i = 0; i < esperado.ProdutosDoPedido.Count; i++)
			{
				Assert.AreEqual(esperado.ProdutosDoPedido[i].DataHoraPedido, obtido.ProdutosDoPedido[i].DataHoraPedido);
				Assert.AreEqual(esperado.ProdutosDoPedido[i].Id, obtido.ProdutosDoPedido[i].Id);
				Assert.AreEqual(esperado.ProdutosDoPedido[i].Quantidade, obtido.ProdutosDoPedido[i].Quantidade);
				Assert.AreEqual(esperado.ProdutosDoPedido[i].Status, obtido.ProdutosDoPedido[i].Status);
				Assert.AreEqual(esperado.ProdutosDoPedido[i].ValorUnitario, obtido.ProdutosDoPedido[i].ValorUnitario);
				if (esperado.ProdutosDoPedido[i].Produto != null)
				{
					Assert.AreEqual(esperado.ProdutosDoPedido[i].Produto.Id, obtido.ProdutosDoPedido[i].Produto.Id);
					Assert.AreEqual(esperado.ProdutosDoPedido[i].Produto.Descricao, obtido.ProdutosDoPedido[i].Produto.Descricao);
					Assert.AreEqual(esperado.ProdutosDoPedido[i].Produto.Foto, obtido.ProdutosDoPedido[i].Produto.Foto);
					Assert.AreEqual(esperado.ProdutosDoPedido[i].Produto.Nome, obtido.ProdutosDoPedido[i].Produto.Nome);
					Assert.AreEqual(esperado.ProdutosDoPedido[i].Produto.Preco, obtido.ProdutosDoPedido[i].Produto.Preco);
				}
			}
		}
	}
}
