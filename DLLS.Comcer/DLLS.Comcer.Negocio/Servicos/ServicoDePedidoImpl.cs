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
	public class ServicoDePedidoImpl : ServicoPadraoImpl<Pedido, DtoPedido>, IServicoDePedido
	{
		private IConversorPedido _conversor;
		private IValidadorPedido _validador;

		public ServicoDePedidoImpl(IRepositorioPedido repositorio) : base(repositorio)
		{
		}

		public override DtoSaida<DtoPedido> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			var lista = base.Liste(pagina, quantidade, ordem, termoDeBusca);

			Parallel.ForEach(lista.Resultados, x => ComprimaFotoProduto(ref x));

			return lista;
		}

		public IList<DtoPedidoView> ListePedidosView()
		{
			return Conversor().Converta(((IRepositorioPedido)_repositorio).ObtenhaPedidos());
		}

		public IList<DtoPedidosComandaView> ListePedidosComandaView()
		{
			var lista = Conversor().Converta(((IRepositorioPedido)_repositorio).ObtenhaPedidosComanda());

			Parallel.ForEach(lista, x => x.FotoProdutoDoPedido = CompressorDeImagem.ComprimaFotoProduto(x.FotoProdutoDoPedido));

			return lista;
		}

		protected override IValidadorPadrao<Pedido> Validador()
		{
			return _validador ??= new ValidadorPedido();
		}

		protected override IConversorPedido Conversor()
		{
			return _conversor ??= new ConversorPedido();
		}

		private static void ComprimaFotoProduto(ref DtoPedido saidaPedido)
		{
			foreach (var saidaProduto in saidaPedido.ProdutosDoPedido)
			{
				saidaProduto.Produto.Foto = CompressorDeImagem.ComprimaFotoProduto(saidaProduto.Produto.Foto);
			}
		}
	}
}
