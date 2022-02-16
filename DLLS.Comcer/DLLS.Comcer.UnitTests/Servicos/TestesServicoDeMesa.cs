using System;
using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Dominio.Objetos.MesaObj;
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
	public class TestesServicoDeMesa : ServicoTestHelper<DtoMesa, Mesa>
	{
		private static Mock<IRepositorioMesa> repository;
		private static Mock<IServicoDeComanda> servicoComanda;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			repository = new Mock<IRepositorioMesa>();
			servicoComanda = new Mock<IServicoDeComanda>();
		}

		[TestMethod]
		public void ObtenhaMesasAtivas()
		{
			repository.Setup(X => X.Liste()).Returns(new List<Mesa> { ObtenhaObj(1) });
			servico = new ServicoDeMesaImpl(repository.Object, servicoComanda.Object);
			IList<int> retorno = ((ServicoDeMesaImpl)servico).ObtenhaMesasAtivas();
			Assert.AreEqual(1, retorno[0]);
		}

		[TestMethod]
		public void ObtenhaMesasAtivasEhZero()
		{
			repository.Setup(X => X.Liste()).Returns(new List<Mesa>());
			servico = new ServicoDeMesaImpl(repository.Object, servicoComanda.Object);
			IList<int> retorno = ((ServicoDeMesaImpl)servico).ObtenhaMesasAtivas();
			Assert.IsFalse(retorno.Any());
		}

		[TestMethod]
		public void TestaObtenhaComandas()
		{
			repository.Setup(X => X.Liste()).Returns(new List<Mesa> { ObtenhaObj(1) });
			servico = new ServicoDeMesaImpl(repository.Object, servicoComanda.Object);
			DtoSaida<DtoComanda> retorno = ((ServicoDeMesaImpl)servico).ObtenhaComandas(1);
			DtoSaida<DtoComanda> esperado = EncapsuleDto(ObtenhaDto(1).Comandas.First(), true);
			AssertDtoSaidaComandaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaIncluaComanda()
		{
			var mesaSemComanda = ObtenhaObj(1);
			mesaSemComanda.Comandas.Clear();
			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(mesaSemComanda);
			repository.Setup(X => X.Atualize(It.IsAny<Mesa>())).Returns(ObtenhaObj(1));
			servicoComanda.Setup(x => x.TrateInclusaoDeComanda(It.IsAny<DtoComanda>())).Returns(ObtenhaDtoComanda());
			servico = new ServicoDeMesaImpl(repository.Object, servicoComanda.Object);
			DtoSaida<DtoMesa> retorno = ((ServicoDeMesaImpl)servico).IncluaComanda(1, ObtenhaDtoComanda());
			DtoSaida<DtoMesa> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaAtualizeMesa()
		{
			repository.Setup(X => X.Atualize(It.IsAny<Mesa>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeMesaImpl(repository.Object, servicoComanda.Object);
			DtoSaida<DtoMesa> retorno = servico.Atualize(ObtenhaDto(1));
			DtoSaida<DtoMesa> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void TestaExcluaMesa(bool sucesso)
		{
			if (sucesso)
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>()));
				servico = new ServicoDeMesaImpl(repository.Object, servicoComanda.Object);
				servico.Exclua(1);
			}
			else
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>())).Throws(new Exception());
				servico = new ServicoDeMesaImpl(repository.Object, servicoComanda.Object);
				Assert.ThrowsException<Exception>(() => servico.Exclua(1));
			}
		}

		public override DtoMesa ObtenhaDto(int codigo = 0)
		{
			return new DtoMesa {
				Id = codigo,
				Disponivel = !ConstantesTestes.BOOL,
				Numero = codigo,
				Comandas = new List<DtoComanda>{
					ObtenhaDtoComanda(codigo)
				}

			};
		}

		public DtoComanda ObtenhaDtoComanda(int codigo = 0)
		{
			return new DtoComanda {
				Id = codigo,
				Nome = ConstantesTestes.STRING,
				Valor = ConstantesTestes.DECIMAL,
				Status = EnumStatusComanda.ABERTA,
				ListaPedidos = new List<DtoPedido> {
							new DtoPedido {
								DataHoraPedido = ConstantesTestes.DATA,
								Id = codigo,
								ProdutosDoPedido = new List<DtoProdutoDoPedido> {
									new DtoProdutoDoPedido{
										DataHoraPedido = ConstantesTestes.DATA,
										Id = codigo,
										Quantidade = ConstantesTestes.INT,
										Status = EnumStatusPedido.COZINHANDO,
										ValorUnitario = ConstantesTestes.DECIMAL
									}
								}
							}
						}
			};
		}

		public override Mesa ObtenhaObj(int codigo = 0)
		{
			return new Mesa {
				Id = codigo,
				Disponivel = !ConstantesTestes.BOOL,
				Numero = codigo,
				Comandas = new List<Comanda>{
					new Comanda {
						Id = codigo,
						Nome = ConstantesTestes.STRING,
						Valor = ConstantesTestes.DECIMAL,
						Status = EnumStatusComanda.ABERTA,
						ListaPedidos = new List<Pedido> {
							new Pedido {
								DataHoraPedido = ConstantesTestes.DATA,
								Id = codigo,
								ProdutosDoPedido = new List<ProdutoDoPedido> {
									new ProdutoDoPedido{
										DataHoraPedido = ConstantesTestes.DATA,
										Id = codigo,
										Quantidade = ConstantesTestes.INT,
										Status = EnumStatusPedido.COZINHANDO,
										ValorUnitario = ConstantesTestes.DECIMAL
									}
								}
							}
						}
					}
				}
			};
		}

		public override void AssertDtoEhIgual(DtoMesa esperado, DtoMesa obtido)
		{
			Assert.AreEqual(esperado.Id, obtido.Id);
			Assert.AreEqual(esperado.Disponivel, obtido.Disponivel);
			Assert.AreEqual(esperado.Numero, obtido.Numero);

			Assert.AreEqual(esperado.Comandas.Any(), obtido.Comandas.Any());
			Assert.AreEqual(esperado.Comandas.Count, obtido.Comandas.Count);
			for (int i = 0; i < esperado.Comandas.Count; i++)
			{
				AssertDtoComandaEhIgual(esperado.Comandas[i], obtido.Comandas[i]);
			}
		}

		public static void AssertDtoComandaEhIgual(DtoComanda esperado, DtoComanda obtido)
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
					Assert.AreEqual(esperado.ListaPedidos[o].DataHoraPedido, obtido.ListaPedidos[o].DataHoraPedido);
					Assert.AreEqual(esperado.ListaPedidos[o].Id, obtido.ListaPedidos[o].Id);
					if (esperado.ListaPedidos[o].ProdutosDoPedido != null && obtido.ListaPedidos[o].ProdutosDoPedido != null)
					{
						Assert.AreEqual(esperado.ListaPedidos[o].ProdutosDoPedido.Any(), obtido.ListaPedidos[o].ProdutosDoPedido.Any());
						Assert.AreEqual(esperado.ListaPedidos[o].ProdutosDoPedido.Count, obtido.ListaPedidos[o].ProdutosDoPedido.Count);
						for (int p = 0; p < esperado.ListaPedidos[o].ProdutosDoPedido.Count; p++)
						{
							Assert.AreEqual(esperado.ListaPedidos[o].ProdutosDoPedido[p].DataHoraPedido, obtido.ListaPedidos[o].ProdutosDoPedido[p].DataHoraPedido);
							Assert.AreEqual(esperado.ListaPedidos[o].ProdutosDoPedido[p].Id, obtido.ListaPedidos[o].ProdutosDoPedido[p].Id);
							Assert.AreEqual(esperado.ListaPedidos[o].ProdutosDoPedido[p].Quantidade, obtido.ListaPedidos[o].ProdutosDoPedido[p].Quantidade);
							Assert.AreEqual(esperado.ListaPedidos[o].ProdutosDoPedido[p].Status, obtido.ListaPedidos[o].ProdutosDoPedido[p].Status);
							Assert.AreEqual(esperado.ListaPedidos[o].ProdutosDoPedido[p].ValorUnitario, obtido.ListaPedidos[o].ProdutosDoPedido[p].ValorUnitario);
						}
					}
				}
			}
		}

		private void AssertDtoSaidaComandaEhIgual(DtoSaida<DtoComanda> esperado, DtoSaida<DtoComanda> obtido)
		{
			Assert.AreEqual(esperado.Pagina, obtido.Pagina);
			Assert.AreEqual(esperado.Quantidade, obtido.Quantidade);
			Assert.AreEqual(esperado.Sucesso, obtido.Sucesso);
			Assert.AreEqual(esperado.Total, obtido.Total);
			Assert.AreEqual(esperado.Validacoes, obtido.Validacoes);
			Assert.AreEqual(esperado.Resultados.Any(), obtido.Resultados.Any());
			Assert.AreEqual(esperado.Resultados.Count, obtido.Resultados.Count);
			for (int i = 0; i < esperado.Resultados.Count; i++)
			{
				AssertDtoComandaEhIgual(esperado.Resultados[i], obtido.Resultados[i]);
			}
		}
	}
}