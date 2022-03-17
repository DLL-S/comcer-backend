using System.Threading.Tasks;
using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;
using DLLS.Comcer.Utilitarios.Enumeradores;
using DLLS.Comcer.Utilitarios.Utils;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeProdutoImpl : ServicoPadraoImpl<Produto, DtoProduto>, IServicoDeProduto
	{
		private IConversorProduto _conversor;
		private IValidadorProduto _validador;

		public ServicoDeProdutoImpl(IRepositorioProduto repositorio) : base(repositorio)
		{
		}

		public override DtoSaida<DtoProduto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			DtoSaida<DtoProduto> lista = base.Liste(pagina, quantidade, ordem, termoDeBusca);
			Parallel.ForEach(lista.Resultados, x => ComprimaFotoProduto(ref x));

			return lista;
		}

		private static void ComprimaFotoProduto(ref DtoProduto saidaProduto)
		{
			saidaProduto.Foto = CompressorDeImagem.ComprimaFotoProduto(saidaProduto.Foto);
		}

		protected override IValidadorPadrao<Produto> Validador()
		{
			return _validador ??= new ValidadorProduto();
		}

		protected override IConversorPadrao<Produto, DtoProduto> Conversor()
		{
			return _conversor ??= new ConversorProduto();
		}
	}
}
