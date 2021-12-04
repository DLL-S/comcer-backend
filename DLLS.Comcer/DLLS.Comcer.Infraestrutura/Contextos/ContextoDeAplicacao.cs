using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Dominio.Objetos.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura.Contextos
{
	public class ContextoDeAplicacao : DbContext
	{
		public ContextoDeAplicacao(DbContextOptions<ContextoDeAplicacao> opcoes) : base(opcoes)
		{

		}

		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }
	}
}
