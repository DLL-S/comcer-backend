using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.Conversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;

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

		public TDto Atualize(TDto objeto)
		{
			var objetoConvertido = _conversor.Converta(objeto);

			CentralDeValidacoes.inserirRetornoValidacao(ref objeto, objetoConvertido, (a) => new List<InconsistenciaDeValidacao>());
			if (objeto.Sucesso == false)
			{
				return objeto;
			}

			_repositorio.Atualize(objetoConvertido);
			return objeto;
		}

		public TDto Cadastre(TDto objeto)
		{
			var objetoConvertido = _conversor.Converta(objeto);

			CentralDeValidacoes.inserirRetornoValidacao(ref objeto, objetoConvertido, (a) => new List<InconsistenciaDeValidacao>());
			if (objeto.Sucesso == false)
			{
				return objeto;
			}

			_repositorio.Cadastre(objetoConvertido);
			return objeto;
		}

		public TDto Consulte(long codigo)
		{
			var objetoConsultado = _repositorio.Consulte(codigo);

			if (objetoConsultado == null)
			{
				return null;
			}

			return _conversor.Converta(objetoConsultado);
		}

		public void Exclua(long codigo)
		{
			_repositorio.Exclua(codigo);
		}

		public IList<TDto> Liste()
		{
			return _conversor.Converta(_repositorio.ConsulteLista());
		}

		public IList<TDto> Liste(int pagina, int quantidade, EnumOrdem ordem)
		{
			return _conversor.Converta(_repositorio.ConsulteLista(pagina, quantidade, ordem));
		}
	}
}
