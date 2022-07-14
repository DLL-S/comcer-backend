using System.Collections.Generic;
using System.Linq;
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
		private IServicoDeComanda _servicoDeComanda;

		public ServicoDeProdutosDoPedidoImpl(IRepositorioProdutoDoPedido repositorio, IServicoDeComanda servicoDeComanda) : base(repositorio)
		{
			_servicoDeComanda = servicoDeComanda;
		}

		public override DtoSaida<DtoProdutoDoPedido> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			DtoSaida<DtoProdutoDoPedido> lista = base.Liste(pagina, quantidade, ordem, termoDeBusca);
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

			if (status == EnumStatusPedido.CANCELADO)
			{
				obj.ValorUnitario = 0;
				DtoComanda comanda = _servicoDeComanda.ObtenhaComandaDoProdutoPedido(codigo);

				var pedidoCancelado = comanda.ListaPedidos.FirstOrDefault(x => x.ProdutosDoPedido.Any(y => y.Id == codigo));

				var produtosDoPedido = pedidoCancelado.ProdutosDoPedido.ToList();

				produtosDoPedido.RemoveAll(y => y.Id == codigo);

				produtosDoPedido.Add(obj);

				pedidoCancelado.ProdutosDoPedido = produtosDoPedido;

				DtoComanda comandaParaInclusao = _servicoDeComanda.TrateInclusaoDeComanda(comanda);
				_servicoDeComanda.Atualize(comandaParaInclusao);
			}

			return base.Atualize(obj);
		}

		public IList<DtoPedidoProdutoView> ListeItensDoPedido(int numeroPedido)
		{
			return Conversor().Converta(((IRepositorioProdutoDoPedido)_repositorio).ListePedidoDoProdutoView(numeroPedido));
		}
	}
}
