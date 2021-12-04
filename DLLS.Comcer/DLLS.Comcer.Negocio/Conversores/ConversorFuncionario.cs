using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Interfaces.Conversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorFuncionario : ConversorPadrao<Funcionario, DtoFuncionario>, IConversorFuncionario
	{
		ConversorEndereco conversorEndereco;

		public override DtoFuncionario Converta(Funcionario objeto)
		{
			var dto = base.Converta(objeto);
			dto.Endereco = ConversorEndereco().Converta(objeto.Endereco);

			return dto;
		}

		public override Funcionario Converta(DtoFuncionario dto)
		{
			var objeto = base.Converta(dto);
			objeto.Endereco = ConversorEndereco().Converta(dto.Endereco);
			return objeto;
		}

		private ConversorEndereco ConversorEndereco()
		{
			return conversorEndereco ??= new ConversorEndereco();
		}
	}
}
