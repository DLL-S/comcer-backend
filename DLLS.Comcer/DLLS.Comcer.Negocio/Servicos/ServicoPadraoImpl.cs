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
			_repositorio.Atualize(_conversor.Converta(objeto));
			return objeto;
		}

		public TDto Cadastre(TDto objeto)
		{
			_repositorio.Cadastre(_conversor.Converta(objeto));
			return objeto;
		}

		public TDto Consulte(long codigo)
		{
			return _conversor.Converta(_repositorio.Consulte(codigo));
		}

		public void Exclua(long codigo)
		{
			_repositorio.Exclua(codigo);
		}

		public IList<TDto> Liste()
		{
			return _conversor.Converta(_repositorio.ConsulteLista());
		}
	}
}
