using System.Collections.Generic;
using System.Threading.Tasks;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;
using DLLS.Comcer.Utilitarios.Enumeradores;
using DLLS.Comcer.Utilitarios.Utils;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeProdutosDoPedidoImpl : ServicoPadraoImpl<ProdutoDoPedido, DtoProdutoDoPedido>, IServicoDeProdutosDoPedido
	{
		private IConversorProdutoDoPedido _conversor;
		private IValidadorProdutoDoPedido _validador;

		public ServicoDeProdutosDoPedidoImpl(IRepositorioProdutoDoPedido repositorio) : base(repositorio)
		{
		}

		public override DtoSaida<DtoProdutoDoPedido> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			var lista = base.Liste(pagina, quantidade, ordem, termoDeBusca);
			Parallel.ForEach(lista.Resultados, x => x.Produto.Foto = CompressorDeImagem.ComprimaFotoProduto(x.Produto.Foto));
			return lista;
		}

		protected override IValidadorProdutoDoPedido Validador()
		{
			return _validador ??= new ValidadorProdutoDoPedido();
		}

		protected override IConversorProdutoDoPedido Conversor()
		{
			return _conversor ??= new ConversorProdutoDoPedido();
		}

		public DtoSaida<DtoProdutoDoPedido> AtualizeStatus(int codigo, EnumStatusPedido status)
		{
			DtoProdutoDoPedido obj = Conversor().Converta(_repositorio.Consulte(codigo));
			obj.Status = status;
			return base.Atualize(obj);
		}

		public IList<DtoPedidoProdutoView> ListeItensDoPedido(int numeroPedido)
		{
			return Conversor().Converta(((IRepositorioProdutoDoPedido)_repositorio).ListePedidoDoProdutoView(numeroPedido));
		}
	}
}
