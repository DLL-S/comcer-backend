using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Interfaces.InterfacesDeServicos
{
	public interface IServicoDeUsuario
	{
		DtoLogin ObtenhaRegistro(string usuario, string senha);
		DtoSaida<DtoFuncionario> CadastreUsuario(DtoLogin login, DtoFuncionario funcionario);
	}
}
