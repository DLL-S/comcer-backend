using DLLS.Comcer.Dominio.Objetos.Funcionario;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios
{
	public class RepositorioFuncionario : RepositorioObjetoComIdNumerico<Funcionario>, IRepositorioFuncionario
	{
		/// <summary>
		/// Construtor padrão.
		/// </summary>
		/// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
		public RepositorioFuncionario(ContextoPadrao contexto)
			: base(contexto) { }

		public Funcionario AlterneAtivacao(long codigo)
		{
			var obj = base.Consulte(codigo);

			obj.Situacao = EnumSituacao.ATIVO != obj.Situacao ? EnumSituacao.ATIVO : EnumSituacao.INATIVO;

			return Atualize(obj);
		}
	}
}
