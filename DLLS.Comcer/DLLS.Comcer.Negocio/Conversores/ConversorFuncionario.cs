using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorFuncionario : ConversorPadrao<Funcionario, DtoFuncionario>, IConversorFuncionario
	{
		private ConversorEndereco conversorEndereco;

		public override DtoFuncionario Converta(Funcionario objeto)
		{
			DtoFuncionario dto = base.Converta(objeto);
			dto.Endereco = ConversorEndereco().Converta(objeto.Endereco);

			return dto;
		}

		public override Funcionario Converta(DtoFuncionario dto)
		{
			Funcionario objeto = base.Converta(dto);
			objeto.Endereco = ConversorEndereco().Converta(dto.Endereco);
			return objeto;
		}

		private ConversorEndereco ConversorEndereco()
		{
			return conversorEndereco ??= new ConversorEndereco();
		}
	}
}
