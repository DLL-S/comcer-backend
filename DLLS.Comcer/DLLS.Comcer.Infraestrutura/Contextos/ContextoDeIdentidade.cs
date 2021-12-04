using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLS.Comcer.Dominio.Objetos.Usuario;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura.Contextos
{
	public class ContextoDeIdentidade : IdentityDbContext<Usuario>
	{
		public ContextoDeIdentidade(DbContextOptions options) : base(options)
		{
		}
	}
}
