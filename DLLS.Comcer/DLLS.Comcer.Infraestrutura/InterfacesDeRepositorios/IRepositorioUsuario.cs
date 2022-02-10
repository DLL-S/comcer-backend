using DLLS.Comcer.Dominio.Objetos.IdentityObj;

namespace DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios
{
	public interface IRepositorioUsuario
	{
		public Usuario ConsultePorLogin(string usuario, string senha);
		public Usuario Cadastre(Usuario usuario);
	}
}
