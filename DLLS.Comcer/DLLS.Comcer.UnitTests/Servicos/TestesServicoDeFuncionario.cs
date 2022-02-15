using System;
using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Servicos;
using DLLS.Comcer.Utilitarios.Enumeradores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DLLS.Comcer.UnitTests.Servicos
{
	[TestClass]
	public class TestesServicoDeFuncionario : ServicoTestHelper<DtoFuncionario, Funcionario>
	{
		private static Mock<IRepositorioFuncionario> repository;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			repository = new Mock<IRepositorioFuncionario>();
		}

		[TestMethod]
		public void TestaCadastreFuncionario()
		{
			repository.Setup(X => X.Cadastre(It.IsAny<Funcionario>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeFuncionarioImpl(repository.Object);
			DtoSaida<DtoFuncionario> esperado = EncapsuleDto(ObtenhaDto(1), true);
			DtoSaida<DtoFuncionario> retorno = servico.Cadastre(ObtenhaDto());
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaConsulteFuncionario()
		{
			repository.Setup(X => X.Consulte(It.IsAny<int>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeFuncionarioImpl(repository.Object);
			DtoSaida<DtoFuncionario> retorno = servico.Consulte(1);
			DtoSaida<DtoFuncionario> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaListeFuncionario()
		{
			repository.Setup(X => X.Liste(1, 1, EnumOrdem.ASC, null)).Returns(new List<Funcionario> { ObtenhaObj(1) });
			servico = new ServicoDeFuncionarioImpl(repository.Object);
			DtoSaida<DtoFuncionario> retorno = servico.Liste(1, 1, EnumOrdem.ASC, null);
			DtoSaida<DtoFuncionario> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		public void TestaAtualizeFuncionario()
		{
			repository.Setup(X => X.Atualize(It.IsAny<Funcionario>())).Returns(ObtenhaObj(1));
			servico = new ServicoDeFuncionarioImpl(repository.Object);
			DtoSaida<DtoFuncionario> retorno = servico.Atualize(ObtenhaDto(1));
			DtoSaida<DtoFuncionario> esperado = EncapsuleDto(ObtenhaDto(1), true);
			AssertDtoSaidaEhIgual(esperado, retorno);
		}

		[TestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void TestaExcluaFuncionario(bool sucesso)
		{
			if (sucesso)
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>()));
				servico = new ServicoDeFuncionarioImpl(repository.Object);
				servico.Exclua(1);
			}
			else
			{
				repository.Setup(X => X.Exclua(It.IsAny<int>())).Throws(new Exception());
				servico = new ServicoDeFuncionarioImpl(repository.Object);
				Assert.ThrowsException<Exception>(() => servico.Exclua(1));
			}
		}
		public override DtoFuncionario ObtenhaDto(int codigo = 0)
		{
			return new DtoFuncionario {
				Id = codigo,
				Celular = ConstantesTestes.STRING,
				CPF = "98263558018",
				DataNascimento = ConstantesTestes.DATA,
				Endereco = new DtoEndereco {
					Bairro = ConstantesTestes.STRING,
					Cidade = ConstantesTestes.STRING,
					Complemento = ConstantesTestes.STRING,
					Estado = ConstantesTestes.STRING,
					Rua = ConstantesTestes.STRING,
					Cep = ConstantesTestes.STRING,
					Id = ConstantesTestes.INT,
					Numero = ConstantesTestes.INT,
				},
				Nome = ConstantesTestes.STRING,
				Situacao = EnumSituacao.ATIVO,
				Email = ConstantesTestes.STRING + "@mail.com"
			};
		}

		public override Funcionario ObtenhaObj(int codigo = 0)
		{
			return new Funcionario {
				Id = codigo,
				Celular = ConstantesTestes.STRING,
				CPF = "98263558018",
				DataNascimento = ConstantesTestes.DATA,
				Endereco = new Endereco {
					Bairro = ConstantesTestes.STRING,
					Cidade = ConstantesTestes.STRING,
					Complemento = ConstantesTestes.STRING,
					Estado = ConstantesTestes.STRING,
					Rua = ConstantesTestes.STRING,
					Cep = ConstantesTestes.STRING,
					Id = ConstantesTestes.INT,
					Numero = ConstantesTestes.INT,
				},
				Nome = ConstantesTestes.STRING,
				Situacao = EnumSituacao.ATIVO,
				Email = ConstantesTestes.STRING + "@mail.com"
			};
		}

		public override void AssertDtoEhIgual(DtoFuncionario esperado, DtoFuncionario obtido)
		{
			Assert.AreEqual(esperado.Id, obtido.Id);
			Assert.AreEqual(esperado.Nome, obtido.Nome);
			Assert.AreEqual(esperado.Celular, obtido.Celular);
			Assert.AreEqual(esperado.CPF, obtido.CPF);
			Assert.AreEqual(esperado.DataNascimento, obtido.DataNascimento);
			Assert.AreEqual(esperado.Situacao, obtido.Situacao);
			Assert.AreEqual(esperado.Email, obtido.Email);
			Assert.AreEqual(esperado.Endereco.Bairro, obtido.Endereco.Bairro);
			Assert.AreEqual(esperado.Endereco.Cidade, obtido.Endereco.Cidade);
			Assert.AreEqual(esperado.Endereco.Complemento, obtido.Endereco.Complemento);
			Assert.AreEqual(esperado.Endereco.Estado, obtido.Endereco.Estado);
			Assert.AreEqual(esperado.Endereco.Rua, obtido.Endereco.Rua);
			Assert.AreEqual(esperado.Endereco.Cep, obtido.Endereco.Cep);
			Assert.AreEqual(esperado.Endereco.Numero, obtido.Endereco.Numero);
			Assert.AreEqual(esperado.Endereco.Id, obtido.Endereco.Id);
		}
	}
}
