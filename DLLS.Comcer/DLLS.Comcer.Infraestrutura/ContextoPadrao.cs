using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Dominio.Objetos.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura
{
    public class ContextoPadrao : DbContext
    {
        public ContextoPadrao(DbContextOptions<ContextoPadrao> opcoes) : base(opcoes)
        {

        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
