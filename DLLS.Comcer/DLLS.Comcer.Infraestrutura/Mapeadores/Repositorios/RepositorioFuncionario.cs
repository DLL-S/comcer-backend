using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
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
		public RepositorioFuncionario(ContextoDeAplicacao contexto)
			: base(contexto) { }

		/// <summary>
		/// Altera a situacao de um Funcionario.
		/// </summary>
		/// <param name="codigo">O código do funcionário.</param>
		/// <returns>O <see cref="EnumSituacao"/> do funcionário.</returns>
		public EnumSituacao AlterneAtivacao(int codigo)
		{
			Funcionario obj = base.Consulte(codigo);

			obj.Situacao = EnumSituacao.ATIVO != obj.Situacao ? EnumSituacao.ATIVO : EnumSituacao.INATIVO;
			Contexto.SaveChanges();

			return obj.Situacao;
		}

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		protected override IList<Funcionario> ListeComTermoDeBusca(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			return ordem == EnumOrdem.ASC
				? Persistencia.Where(x => x.Nome.Contains(termoDeBusca)).OrderBy(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList()
				: Persistencia.Where(x => x.Nome.Contains(termoDeBusca)).OrderByDescending(x => x.Id).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
		}
	}
}
