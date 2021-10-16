using System;
using DLLS.Comcer.Dominio;
using DLLS.Comcer.Infraestrutura.Identity;
using DLLS.Comcer.Infraestrutura.Mapeadores;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura
{
    public class ContextoPadrao : IdentityDbContext<Usuario>
	{
		public ContextoPadrao(DbContextOptions<ContextoPadrao> opcoes) : base(opcoes)
		{

		}

		public DbSet<Funcionario> Funcionarios { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new FuncionarioMap());
		}
	}
}
