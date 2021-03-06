using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Validacoes;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Negocio.Servicos
{
	public abstract class ServicoPadraoImpl<TObjeto, TDto> : IServicoPadrao<TDto>
		where TDto : DtoBase
		where TObjeto : ObjetoComIdNumerico
	{
		protected readonly IRepositorioObjetoComIdNumerico<TObjeto> _repositorio;

		protected ServicoPadraoImpl(IRepositorioObjetoComIdNumerico<TObjeto> repositorio)
		{
			_repositorio = repositorio;
		}

		#region CRUD

		/// <summary>
		/// Consulta um item pelo código.
		/// </summary>
		/// <param name="codigo">O código do item a ser pesquisado.</param>
		/// <returns>Um Dto com o item encontrado ou null.</returns>
		public virtual DtoSaida<TDto> Consulte(int codigo)
		{
			TObjeto objetoConsultado = _repositorio.Consulte(codigo);

			if (objetoConsultado == null)
			{
				return null;
			}

			var saida = Conversor().ConvertaParaDtoSaida(objetoConsultado);
			saida.Total = _repositorio.Count();
			saida.Quantidade = 1;
			saida.Pagina = 0;

			return saida;
		}

		/// <summary>
		/// Retorna uma lista com todos os registros da base (Utilize com cuidado).
		/// </summary>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		public virtual DtoSaida<TDto> Liste()
		{
			var saida = Conversor().ConvertaParaDtoSaida(_repositorio.Liste());
			saida.Total = _repositorio.Count();
			saida.Quantidade = saida.Resultados.Count;
			saida.Pagina = 0;

			return saida;
		}

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		public virtual DtoSaida<TDto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			var saida = Conversor().ConvertaParaDtoSaida(_repositorio.Liste(pagina, quantidade, ordem, termoDeBusca));
			saida.Total = _repositorio.Count();
			saida.Quantidade = saida.Resultados.Count;
			saida.Pagina = pagina;
			return saida;
		}

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoBuscado">O termo de busca para a pesquisa.</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		public DtoSaida<TDto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoBuscado, string termoDeBusca)
		{
			var saida = Conversor().ConvertaParaDtoSaida(_repositorio.Liste(pagina, quantidade, ordem, termoBuscado, termoDeBusca));
			saida.Total = _repositorio.Count();
			saida.Quantidade = saida.Resultados.Count;
			saida.Pagina = pagina;
			return saida;
		}

		/// <summary>
		/// Cadastrda um novo item na base.
		/// </summary>
		/// <param name="objeto">O Dto a ser cadastrado.</param>
		/// <returns>Retorna o Dto com uma indicação de Sucesso true ou false.</returns>
		public virtual DtoSaida<TDto> Cadastre(TDto objeto)
		{
			TObjeto objetoConvertido = Conversor().Converta(objeto);
			DtoSaida<TDto> dtoSaida = Conversor().ConvertaParaDtoSaida(objeto);

			Validador().AssineRegrasCadastro();
			CentralDeValidacoes<TDto>.Valide(ref dtoSaida, objetoConvertido, Validador());

			if (dtoSaida.Sucesso)
				dtoSaida.Resultados[0] = Conversor().Converta(_repositorio.Cadastre(objetoConvertido));

			dtoSaida.Total = _repositorio.Count();
			dtoSaida.Quantidade = 1;

			return dtoSaida;
		}

		/// <summary>
		/// Atualiza um item na base.
		/// </summary>
		/// <param name="objeto">O Dto do item a ser atualizado.</param>
		/// <returns>Retorna o Dto com uma indicação de Sucesso true ou false.</returns>
		public virtual DtoSaida<TDto> Atualize(TDto objeto)
		{
			TObjeto objetoConvertido = Conversor().Converta(objeto);
			DtoSaida<TDto> dtoSaida = Conversor().ConvertaParaDtoSaida(objeto);

			Validador().AssineRegrasAtualizacao();
			CentralDeValidacoes<TDto>.Valide(ref dtoSaida, objetoConvertido, Validador());

			if (dtoSaida.Sucesso)
				dtoSaida.Resultados[0] = Conversor().Converta(_repositorio.Atualize(objetoConvertido));

			dtoSaida.Total = _repositorio.Count();
			dtoSaida.Quantidade = 1;

			return dtoSaida;
		}

		/// <summary>
		/// Exclui um itm da base de dados.
		/// </summary>
		/// <param name="codigo">O código do item a ser excluído</param>
		public virtual void Exclua(int codigo)
		{
			Validador().AssineRegrasExclusao();
			_repositorio.Exclua(codigo);
		}

		#endregion

		/// <summary>
		/// Obtém ou define uma instância da classe de validação do conceito.
		/// </summary>
		/// <returns>A instância da classe de validação.</returns>
		protected abstract IValidadorPadrao<TObjeto> Validador();

		/// <summary>
		/// Obtém ou define uma instância da classe de conversor do conceito.
		/// </summary>
		/// <returns>A instância da classe de conversor.</returns>
		protected abstract IConversorPadrao<TObjeto, TDto> Conversor();
	}
}
