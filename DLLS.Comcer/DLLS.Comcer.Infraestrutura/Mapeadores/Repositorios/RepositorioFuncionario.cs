using System.Collections.Generic;
using System.Linq;
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

		/// <summary>
		/// Consulta uma lista de objetos no contexto definido.
		/// </summary>
		/// <param name="termoDeBusca">O termo de busca da filtragem.</param>
		/// <param name="quantidade">A quantidade de itens a retornar.</param>
		/// <param name="ordem">A ordem da lista.</param>
		/// <returns>A lista de itens filtrados.</returns>
		public IList<Funcionario> Consulte(string termoDeBusca, int quantidade, EnumOrdem ordem)
		{
			return ordem == EnumOrdem.ASC
				? Persistencia.Where(x => x.Nome.Contains(termoDeBusca)).OrderBy(x => x.Id).Take(quantidade).ToList()
				: Persistencia.Where(x => x.Nome.Contains(termoDeBusca)).OrderByDescending(x => x.Id).Take(quantidade).ToList();
		}
	}
}
