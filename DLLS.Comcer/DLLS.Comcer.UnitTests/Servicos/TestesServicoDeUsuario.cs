using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Servicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DLLS.Comcer.UnitTests.Servicos
{
	[TestClass]
	public class TestesServicoDeUsuario
	{
		private static Mock<IRepositorioUsuario> repository;
		private static IServicoDeUsuario servico;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			repository = new Mock<IRepositorioUsuario>();
		}

		[TestMethod]
		public void TestaCadastreUsuario()
		{
			repository.Setup(X => X.Cadastre(It.IsAny<Usuario>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeUsuarioImpl(repository.Object);
			DtoSaida<DtoFuncionario> esperado = ObtenhaDtoSaidaFuncionario(1);
			DtoSaida<DtoFuncionario> retorno = servico.CadastreUsuario(ObtenhaDto(), ObtenhaDtoFuncionario());
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaObtenhaRegistro()
		{
			repository.Setup(X => X.ConsultePorLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeUsuarioImpl(repository.Object);
			DtoLogin retorno = servico.ObtenhaRegistro("", "");
			DtoLogin esperado = ObtenhaDto();
			AssertDtoEhIgual(esperado, retorno);
		}

		private static DtoSaida<DtoFuncionario> ObtenhaDtoSaidaFuncionario(int codigo = 0)
		{
			return new DtoSaida<DtoFuncionario> {
				Quantidade = ConstantesTestes.INT,
				Resultados = new List<DtoFuncionario>{
					ObtenhaDtoFuncionario(codigo)
				},
				Pagina = 0,
				Sucesso = ConstantesTestes.BOOL,
				Total = 0
			};
		}

		private static DtoFuncionario ObtenhaDtoFuncionario(int codigo = 0)
		{
			return new DtoFuncionario {
				Id = codigo,
				Celular = ConstantesTestes.STRING,
				CPF = "98263558018",
				Nome = ConstantesTestes.STRING,
				Email = ConstantesTestes.STRING + "@mail.com"
			};
		}

		private static void AssertDtoEhIgual(DtoLogin esperado, DtoLogin retorno)
		{
			Assert.AreEqual(esperado.Usuario, retorno.Usuario);
			Assert.AreEqual(esperado.Token, retorno.Token);
			Assert.AreEqual(esperado.Senha, retorno.Senha);
			Assert.AreEqual(esperado.Role, retorno.Role);
		}

		private static void AssertDtoSaidaEhIgual(DtoSaida<DtoFuncionario> esperado, DtoSaida<DtoFuncionario> retorno)
		{
			Assert.AreEqual(esperado.Validacoes, retorno.Validacoes);
			Assert.AreEqual(esperado.Total, retorno.Total);
			Assert.AreEqual(esperado.Sucesso, retorno.Sucesso);
			Assert.AreEqual(esperado.Quantidade, retorno.Quantidade);
			Assert.AreEqual(esperado.Pagina, retorno.Pagina);
			Assert.AreEqual(esperado.Resultados[0].CPF, retorno.Resultados[0].CPF);
			Assert.AreEqual(esperado.Resultados[0].Celular, retorno.Resultados[0].Celular);
			Assert.AreEqual(esperado.Resultados[0].Email, retorno.Resultados[0].Email);
			Assert.AreEqual(esperado.Resultados[0].Nome, retorno.Resultados[0].Nome);
			Assert.AreEqual(esperado.Resultados[0].Id, retorno.Resultados[0].Id);
		}

		private static DtoLogin ObtenhaDto()
		{
			return new DtoLogin {
				Usuario = ConstantesTestes.STRING,
				Senha = ConstantesTestes.STRING,
				Role = "teste"
			};
		}

		private static Usuario ObtenhaObj(int codigo = 0)
		{
			return new Usuario {
				Id = codigo,
				Email = ConstantesTestes.STRING,
				PasswordHash = ConstantesTestes.STRING,
				Funcionario = new Funcionario() {
					Id = codigo,
					Nome = ConstantesTestes.STRING,
					CPF = "98263558018",
					Email = ConstantesTestes.STRING + "@mail.com",
					Celular = ConstantesTestes.STRING
				}
			};
		}
	}
}
