using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeUsuarioImpl : IServicoDeUsuario
	{
		private readonly IRepositorioUsuario _repositorio;

		public ServicoDeUsuarioImpl(IRepositorioUsuario repositorio)
		{
			_repositorio = repositorio;
		}

		public DtoSaida<DtoFuncionario> CadastreUsuario(DtoLogin login, DtoFuncionario funcionario)
		{
			var conversorFuncionario = new ConversorFuncionario();
			var objFuncionario = conversorFuncionario.Converta(funcionario);
			var usuario = new Usuario {
				Email = login.Usuario,
				PasswordHash = login.Senha,
				Funcionario = objFuncionario,
				UserName = objFuncionario.Nome.Trim(),
				PhoneNumber = objFuncionario.Celular
			};

			DtoSaida<DtoFuncionario> dtoSaida = conversorFuncionario.ConvertaParaDtoSaida(usuario.Funcionario);

			var validador = new ValidadorFuncionario();
			validador.AssineRegrasCadastro();
			CentralDeValidacoes<DtoFuncionario>.Valide(ref dtoSaida, usuario.Funcionario, validador);

			if (dtoSaida.Sucesso)
				dtoSaida.Resultados[0].Id = _repositorio.Cadastre(usuario).Funcionario.Id;

			return dtoSaida;
		}

		public DtoLogin ObtenhaRegistro(string usuario, string senha)
		{
			Usuario usuarioConsultado = _repositorio.ConsultePorLogin(usuario, senha);

			if (usuarioConsultado == null)
			{
				return null;
			}

			return new DtoLogin {
				Usuario = usuarioConsultado.Email,
				Senha = usuarioConsultado.PasswordHash,
				Role = "teste"
			};
		}
	}
}
