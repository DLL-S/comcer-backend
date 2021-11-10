using DLLS.Comcer.Dominio.Objetos.Funcionario;

namespace DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios
{
	public interface IRepositorioFuncionario : IRepositorioObjetoComIdNumerico<Funcionario>
	{
		Funcionario AlterneAtivacao(long codigo);
	}
}
