using System;
using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Dominio.Objetos.MesaObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Servicos;
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
		public void ObtenhaMesasAtivasComIndisponivel()
		{
			var mesa = ObtenhaObj(1);
			mesa.Disponivel = false;
			repository.Setup(X => X.Liste()).Returns(new List<Mesa> { mesa });
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
			new TestesServicoDeComanda().AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaIncluaComanda()
		{
			var mesaSemComanda = ObtenhaObj(1);
			mesaSemComanda.Comandas.Clear();
			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(mesaSemComanda);
			repository.Setup(X => X.Atualize(It.IsAny<Mesa>())).Returns(ObtenhaObj(1));
			servicoComanda.Setup(x => x.TrateInclusaoDeComanda(It.IsAny<DtoComanda>())).Returns(new TestesServicoDeComanda().ObtenhaDto());
			servico = new ServicoDeMesaImpl(repository.Object, servicoComanda.Object);
			DtoSaida<DtoMesa> retorno = ((ServicoDeMesaImpl)servico).IncluaComanda(1, new TestesServicoDeComanda().ObtenhaDto());
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
					new TestesServicoDeComanda().ObtenhaDto(codigo)
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
					new TestesServicoDeComanda().ObtenhaObj(codigo)
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
				new TestesServicoDeComanda().AssertDtoEhIgual(esperado.Comandas[i], obtido.Comandas[i]);
			}
		}
	}
}