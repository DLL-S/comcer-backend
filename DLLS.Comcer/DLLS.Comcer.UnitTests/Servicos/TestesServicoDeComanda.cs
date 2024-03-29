﻿using System;
using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Servicos;
using DLLS.Comcer.Utilitarios.Enumeradores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DLLS.Comcer.UnitTests.Servicos
{
	[TestClass]
	public class TestesServicoDeComanda : ServicoTestHelper<DtoComanda, Comanda>
	{
		private static Mock<IRepositorioComanda> repository;
		private static Mock<IServicoDeProduto> servicoProduto;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			repository = new Mock<IRepositorioComanda>();
			servicoProduto = new Mock<IServicoDeProduto>();
		}

		[TestMethod]
		public void TestaIncluaPedido()
		{
			var comandaSemPedido = ObtenhaObj(1);
			comandaSemPedido.ListaPedidos.Clear();
			comandaSemPedido.Valor = 0;

			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(comandaSemPedido);
			repository.Setup(X => X.Atualize(It.IsAny<Comanda>())).Returns(ObtenhaObj(1));
			servicoProduto.Setup(x => x.Consulte(It.IsAny<int>())).Returns(EncapsuleDto(new TestesServicoDeProduto().ObtenhaDto(1), true));

			servico = new ServicoDeComandaImpl(repository.Object, servicoProduto.Object);

			var pedido = new TestesServicoDePedido().ObtenhaDto();
			pedido.ProdutosDoPedido[0].Produto = new TestesServicoDeProduto().ObtenhaDto(1);

			DtoSaida<DtoComanda> retorno = ((ServicoDeComandaImpl)servico).IncluaPedido(1, pedido);
			DtoSaida<DtoComanda> esperado = EncapsuleDto(ObtenhaDto(1), true);
			retorno.Resultados[0].ListaPedidos[0].ProdutosDoPedido[0].Produto = null;
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaIncluaPedidoProdutoNotFound()
		{
			var comandaSemPedido = ObtenhaObj(1);
			comandaSemPedido.ListaPedidos.Clear();
			comandaSemPedido.Valor = 0;

			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(comandaSemPedido);
			repository.Setup(X => X.Atualize(It.IsAny<Comanda>())).Returns(comandaSemPedido);
			servicoProduto.Setup(x => x.Consulte(It.IsAny<int>()));

			servico = new ServicoDeComandaImpl(repository.Object, servicoProduto.Object);

			var pedido = new TestesServicoDePedido().ObtenhaDto();
			pedido.ProdutosDoPedido[0].Produto = new TestesServicoDeProduto().ObtenhaDto(1);

			var dtoComandaSemPedido = ObtenhaDto(1);
			dtoComandaSemPedido.ListaPedidos.Clear();
			dtoComandaSemPedido.Valor = 0;

			DtoSaida<DtoComanda> retorno = ((ServicoDeComandaImpl)servico).IncluaPedido(1, pedido);
			DtoSaida<DtoComanda> esperado = EncapsuleDto(dtoComandaSemPedido, false);

			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaIncluaPedidoComandaNotFound()
		{
			repository.Setup(X => X.Consulte(It.IsAny<int>()));
			servico = new ServicoDeComandaImpl(repository.Object, servicoProduto.Object);

			var pedido = new TestesServicoDePedido().ObtenhaDto();

			DtoSaida<DtoComanda> retorno = ((ServicoDeComandaImpl)servico).IncluaPedido(1, pedido);
			Assert.IsNull(retorno);
		}

		[TestMethod]
		public void TestaIncluaComanda()
		{
			repository.Setup(X => X.Liste()).Returns(new List<Comanda>());
			servicoProduto.Setup(x => x.Consulte(It.IsAny<int>())).Returns(EncapsuleDto(new TestesServicoDeProduto().ObtenhaDto(1), true));
			servico = new ServicoDeComandaImpl(repository.Object, servicoProduto.Object);
			DtoComanda retorno = ((ServicoDeComandaImpl)servico).TrateInclusaoDeComanda(ObtenhaDto());
			retorno.ListaPedidos[0].DataHoraPedido = ConstantesTestes.DATA;
			DtoComanda esperado = ObtenhaDto();
			AssertDtoEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaCadastreComanda()
		{
			repository.Setup(X => X.Liste()).Returns(new List<Comanda>());
			servicoProduto.Setup(x => x.Consulte(It.IsAny<int>())).Returns(EncapsuleDto(new TestesServicoDeProduto().ObtenhaDto(1), true));
			repository.Setup(x => x.Cadastre(It.IsAny<Comanda>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeComandaImpl(repository.Object, servicoProduto.Object);
			DtoSaida<DtoComanda> retorno = ((ServicoDeComandaImpl)servico).Cadastre(ObtenhaDto());
			retorno.Resultados[0].ListaPedidos[0].DataHoraPedido = ConstantesTestes.DATA;
			DtoComanda esperado = ObtenhaDto(1);
			AssertDtoEhIgual(esperado, retorno.Resultados[0]);
		}

		[TestMethod]
		public void TestaAtualizeComanda()
		{
			repository.Setup(X => X.Atualize(It.IsAny<Comanda>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeComandaImpl(repository.Object, servicoProduto.Object);
			DtoSaida<DtoComanda> retorno = servico.Atualize(ObtenhaDto(1));
			DtoSaida<DtoComanda> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void TestaExcluaComanda(bool sucesso)
		{
			if (sucesso)
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>()));
				servico = new ServicoDeComandaImpl(repository.Object, servicoProduto.Object);
				servico.Exclua(1);
			}
			else
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>())).Throws(new Exception());
				servico = new ServicoDeComandaImpl(repository.Object, servicoProduto.Object);
				Assert.ThrowsException<Exception>(() => servico.Exclua(1));
			}
		}

		public override DtoComanda ObtenhaDto(int codigo = 0)
		{
			return new DtoComanda {
				Id = codigo,
				Nome = ConstantesTestes.STRING,
				Valor = ConstantesTestes.DECIMAL,
				Status = EnumStatusComanda.ABERTA,
				ListaPedidos = new List<DtoPedido> {
							 new TestesServicoDePedido().ObtenhaDto()
						}
			};
		}

		public override Comanda ObtenhaObj(int codigo = 0)
		{
			return new Comanda {
				Id = codigo,
				Nome = ConstantesTestes.STRING,
				Valor = ConstantesTestes.DECIMAL,
				Status = EnumStatusComanda.ABERTA,
				ListaPedidos = new List<Pedido> {
							new  TestesServicoDePedido().ObtenhaObj()
						}
			};
		}

		public override void AssertDtoEhIgual(DtoComanda esperado, DtoComanda obtido)
		{
			Assert.AreEqual(esperado.Nome, obtido.Nome);
			Assert.AreEqual(esperado.Id, obtido.Id);
			Assert.AreEqual(esperado.Status, obtido.Status);
			Assert.AreEqual(esperado.Valor, obtido.Valor);
			if (esperado.ListaPedidos != null && obtido.ListaPedidos != null)
			{
				Assert.AreEqual(esperado.ListaPedidos.Any(), obtido.ListaPedidos.Any());
				Assert.AreEqual(esperado.ListaPedidos.Count, obtido.ListaPedidos.Count);
				for (int o = 0; o < esperado.ListaPedidos.Count; o++)
				{
					new TestesServicoDePedido().AssertDtoEhIgual(esperado.ListaPedidos[o], obtido.ListaPedidos[o]);
				}
			}
		}
	}
}