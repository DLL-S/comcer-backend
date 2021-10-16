using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura.Identity
{
   public class IdentityDbContext : IdentityDbContext<Usuario>
	{
		public IdentityDbContext(DbContextOptions opcoes) : base(opcoes)
		{

		}
	}
}
