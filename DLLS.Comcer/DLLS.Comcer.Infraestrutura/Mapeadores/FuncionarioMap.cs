using DLLS.Comcer.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores
{
   internal class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
   {
	  public void Configure(EntityTypeBuilder<Funcionario> builder)
	  {
		 //throw new System.NotImplementedException();
	  }
   }
}
