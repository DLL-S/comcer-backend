using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.Conversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;
using DLLS.Comcer.Utilitarios.Utils;

namespace DLLS.Comcer.Negocio.Servicos
{
	public abstract class ServicoPadraoImpl<TObjeto, TDto> : IServicoPadrao<TDto> where TDto : DtoBase where TObjeto : ObjetoComIdNumerico
	{
		protected readonly IRepositorioObjetoComIdNumerico<TObjeto> _repositorio;
		protected readonly IConversorPadrao<TObjeto, TDto> _conversor;

		protected ServicoPadraoImpl(IRepositorioObjetoComIdNumerico<TObjeto> repositorio, IConversorPadrao<TObjeto, TDto> conversor)
		{
			_repositorio = repositorio;
			_conversor = conversor;
		}

		#region CONSULTAS

		/// <summary>
		/// Consulta um item pelo código.
		/// </summary>
		/// <param name="codigo">O código do item a ser pesquisado.</param>
		/// <returns>Um Dto com o item encontrado ou null.</returns>
		public TDto Consulte(int codigo)
		{
			var objetoConsultado = _repositorio.Consulte(codigo);

			if (objetoConsultado == null)
			{
				return null;
			}

			return _conversor.Converta(objetoConsultado);
		}

		/// <summary>
		/// Retorna uma lista com todos os registros da base (Utilize com cuidado).
		/// </summary>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		public virtual IList<TDto> Liste()
		{
			return _conversor.Converta(_repositorio.Liste());
		}

		/// <summary>
		/// Retorna uma lista com os itens de acordo com os filtros passados.
		/// </summary>
		/// <param name="pagina">O indice do primeiro item a ser retornado (Padrão: 1).</param>
		/// <param name="quantidade">A quantidade de itens a ser retornada (Padrão: 50).</param>
		/// <param name="ordem">A ordem em que os itens deverão ser retornados (Padrã: ASC).</param>
		/// <param name="termoDeBusca">O termo de busca para a pesquisa.</param>
		/// <returns>Uma lista de Dtos com os registros.</returns>
		public virtual IList<TDto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			return _conversor.Converta(_repositorio.Liste(pagina, quantidade, ordem, termoDeBusca));
		}

		#endregion

		/// <summary>
		/// Cadastrda um novo item na base.
		/// </summary>
		/// <param name="dto">O Dto a ser cadastrado.</param>
		/// <returns>Retorna o Dto com uma indicação de Sucesso true ou false.</returns>
		public TDto Cadastre(TDto dto)
		{
			var objetoConvertido = _conversor.Converta(dto);

			CentralDeValidacoes.InserirRetornoValidacao(ref dto, objetoConvertido, (a) => new List<InconsistenciaDeValidacao>());
			if (dto.Sucesso == true)
				_repositorio.Cadastre(objetoConvertido);

			return dto;
		}

		/// <summary>
		/// Atualiza um item na base.
		/// </summary>
		/// <param name="dto">O Dto do item a ser atualizado.</param>
		/// <returns>Retorna o Dto com uma indicação de Sucesso true ou false.</returns>
		public virtual TDto Atualize(TDto dto)
		{
			var objetoConvertido = _conversor.Converta(dto);

			CentralDeValidacoes.InserirRetornoValidacao(ref dto, objetoConvertido, (a) => new List<InconsistenciaDeValidacao>());
			if (dto.Sucesso == true)
				_repositorio.Atualize(objetoConvertido);

			return dto;
		}

		/// <summary>
		/// Exclui um itm da base de dados.
		/// </summary>
		/// <param name="codigo">O código do item a ser excluído</param>
		public virtual void Exclua(int codigo)
		{
			_repositorio.Exclua(codigo);
		}
	}
}
