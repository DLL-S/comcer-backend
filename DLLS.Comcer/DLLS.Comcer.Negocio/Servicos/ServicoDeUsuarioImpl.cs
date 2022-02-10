using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeUsuarioImpl : IServicoDeUsuario
	{
		IRepositorioUsuario _repositorio;

		public ServicoDeUsuarioImpl(IRepositorioUsuario repositorio)
		{
			_repositorio = repositorio;
		}

		public DtoLogin DefinaSenha(string usuario, string senha)
		{
			throw new System.NotImplementedException();
		}

		public DtoLogin ObtenhaRegistro(string usuario, string senha)
		{
			var usuarioConsultado = _repositorio.ConsultePorLogin(usuario, senha);

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
