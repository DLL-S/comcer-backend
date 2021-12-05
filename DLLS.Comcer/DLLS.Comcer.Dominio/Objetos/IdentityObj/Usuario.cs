using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using Microsoft.AspNetCore.Identity;

namespace DLLS.Comcer.Dominio.Objetos.IdentityObj
{
	public class Usuario : IdentityUser<int>
	{
		public virtual Funcionario Funcionario { get; set; }
	}
}
