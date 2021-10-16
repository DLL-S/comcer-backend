using DLLS.Comcer.Dominio;
using DLLS.Comcer.Utilitarios.Enumeradores;
using Microsoft.AspNetCore.Identity;

namespace DLLS.Comcer.Startup.EFCore
{
   public class Usuario : IdentityUser
   {
		public Funcionario Funcionario { get; set; }
		public EnumPerfilDeAcesso Perfil { get; set; }
		public bool Administrador { get; set; }
		public EnumSituacao Situacao { get; set; }
	}
}
