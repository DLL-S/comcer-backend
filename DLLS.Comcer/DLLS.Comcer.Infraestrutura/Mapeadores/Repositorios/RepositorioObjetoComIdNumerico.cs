using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios
{
	public class RepositorioObjetoComIdNumerico<TObjeto> : RepositorioGenerico<TObjeto>, IRepositorioObjetoComIdNumerico<TObjeto>
		 where TObjeto : ObjetoComIdNumerico
	{
		/// <summary>
		/// Construtor padrão.
		/// </summary>
		/// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
		public RepositorioObjetoComIdNumerico(ContextoDeAplicacao contexto)
			 : base(contexto) { }

		/// <summary>
		/// Cadastra um novo objeto no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto a ser cadastrado.</param>
		public virtual TObjeto Cadastre(TObjeto objeto)
		{
			Persistencia.Add(objeto);
			Contexto.SaveChanges();

			return objeto;
		}

		/// <summary>
		/// Consulta um objeto no contexto definido.
		/// </summary>
		/// <param name="Codigo">O código do objeto.</param>
		/// <returns>O objeto da base, ou null caso não exista.</returns>
		public virtual TObjeto Consulte(long Codigo)
		{
			return Persistencia.Where(x => x.Id == Codigo).FirstOrDefault();
		}

		/// <summary>
		/// Consulta todos os registros no contexto definido.
		/// </summary>
		/// <returns>Uma lista com os registros.</returns>
		public virtual IList<TObjeto> ConsulteLista()
		{
			return Persistencia.OrderBy(x => x.Id).ToList();
		}

		/// <summary>
		/// Consulta uma página de registros no contexto definido.
		/// </summary>
		/// <returns>Uma lista com os registros.</returns>
		public virtual IList<TObjeto> ConsulteLista(int pagina, int quantidade, EnumOrdem ordem)
		{
			return ordem == EnumOrdem.ASC
				? Persistencia.OrderBy(x => x.Id).Skip(pagina).Take(quantidade).ToList()
				: Persistencia.OrderByDescending(x => x.Id).Skip(pagina).Take(quantidade).ToList();
		}

		/// <summary>
		/// Consulta uma lista parcial dos registros no contexto definido.
		/// </summary>
		/// <param name="qtdeAPular">A quantidade de registros a ser pulada a partir do primeiro.</param>
		/// <param name="qtdeARetornar">A quantidade de registros a ser retornada.</param>
		/// <returns>Uma lista com os registros.</returns>
		public virtual IList<TObjeto> ConsulteLista(int qtdeAPular, int qtdeARetornar)
		{
			return Persistencia.OrderBy(x => x.Id).Skip(qtdeAPular).Take(qtdeARetornar).ToList();
		}

		/// <summary>
		/// Atualiza um registro no contexto definido.
		/// </summary>
		/// <param name="objeto">O objeto modificado.</param>
		public virtual TObjeto Atualize(TObjeto objeto)
		{
			Persistencia.Update(objeto);
			Contexto.SaveChanges();

			return objeto;
		}

		/// <summary>
		/// Exclui um registro no contexto.
		/// </summary>
		/// <param name="objeto">O objeto a ser excluído.</param>
		public virtual void Exclua(long objeto)
		{
			Persistencia.Remove(Consulte(objeto));
			Contexto.SaveChanges();
		}
	}
}
