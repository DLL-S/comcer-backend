using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos
{
    internal class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        private const string NOME_TABELA = "ENDERECOS";
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable(NOME_TABELA);
            builder.HasKey(x => x.Id);

            #region ID

            builder.Property(x => x.Id)
                 .HasColumnName("ID")
                 .HasColumnType("SERIAL")
                 .UseIdentityAlwaysColumn()
                 .ValueGeneratedOnAdd()
                 .IsRequired();

            builder.HasIndex(x => x.Id)
                 .HasDatabaseName("IDX_IDENDERECO")
                 .IsUnique();

            #endregion

            #region CEP

            builder.Property(x => x.Cep)
                 .HasColumnName("CEP")
                 .HasColumnType("TEXT");

            #endregion

            #region CIDADE

            builder.Property(x => x.Cidade)
                 .HasColumnName("CIDADE")
                 .HasColumnType("TEXT");

            #endregion

            #region COMPLEMENTO

            builder.Property(x => x.Complemento)
                 .HasColumnName("COMPLEMENTO")
                 .HasColumnType("TEXT");

            #endregion

            #region ESTADO

            builder.Property(x => x.Estado)
                 .HasColumnName("ESTADO")
                 .HasColumnType("TEXT");

            #endregion

            #region NUMERO

            builder.Property(x => x.Numero)
                 .HasColumnName("NUMERO")
                 .HasColumnType("NUMERIC")
                 .IsRequired();

            #endregion

            #region RUA

            builder.Property(x => x.Rua)
                 .HasColumnName("RUA")
                 .HasColumnType("TEXT");

            #endregion

            #region BAIRRO

            builder.Property(x => x.Bairro)
                 .HasColumnName("BAIRRO")
                 .HasColumnType("TEXT");

            #endregion
        }
    }
}
