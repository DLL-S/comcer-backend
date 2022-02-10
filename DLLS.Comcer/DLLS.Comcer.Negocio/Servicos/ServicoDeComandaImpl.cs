using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeComandaImpl : ServicoPadraoImpl<Comanda, DtoComanda>, IServicoDeComanda
	{
		private IConversorComanda _conversor;
		private IValidadorComanda _validador;
		private IServicoDeProduto _servicoDeProduto;

		public ServicoDeComandaImpl(IRepositorioComanda repositorio, IServicoDeProduto servicoDeProduto) : base(repositorio)
		{
			_servicoDeProduto = servicoDeProduto;
		}

		public DtoSaida<DtoComanda> IncluaPedido(int codigoComanda, DtoPedido pedido)
		{
			var comanda = Consulte(codigoComanda);

			if (comanda.Sucesso)
			{
				pedido.DataHoraPedido = System.DateTime.Now;
				foreach (var produtoDoPedido in pedido.ProdutosDoPedido)
				{
					var consultaProduto = _servicoDeProduto.Consulte(produtoDoPedido.Produto.Id);

					if (consultaProduto.Sucesso)
					{
						produtoDoPedido.Produto = consultaProduto.Resultados[0];
						produtoDoPedido.ValorUnitario = produtoDoPedido.Produto.Preco;
						produtoDoPedido.DataHoraPedido = pedido.DataHoraPedido;
						comanda.Resultados[0].ListaPedidos.Add(pedido);
						comanda.Resultados[0].Valor += produtoDoPedido.Quantidade * produtoDoPedido.ValorUnitario;

						return Atualize(comanda.Resultados[0]);
					}
					else
					{
						comanda.Sucesso = consultaProduto.Sucesso;
						comanda.Validacoes = consultaProduto.Validacoes;
					}
				}
			}

			return comanda;
		}

		public override DtoSaida<DtoComanda> Cadastre(DtoComanda dto)
		{
			return base.Cadastre(TrateInclusaoDeComanda(dto));
		}

		public DtoComanda TrateInclusaoDeComanda(DtoComanda comanda)
		{
			if (comanda.ListaPedidos != null && comanda.ListaPedidos.Count > 0)
			{
				foreach (var pedido in comanda.ListaPedidos)
				{
					pedido.DataHoraPedido = System.DateTime.Now;
					foreach (var produtoDoPedido in pedido.ProdutosDoPedido)
					{
						produtoDoPedido.Produto = _servicoDeProduto.Consulte(produtoDoPedido.Produto.Id).Resultados[0];
						produtoDoPedido.ValorUnitario = produtoDoPedido.Produto.Preco;
						comanda.Valor += produtoDoPedido.Quantidade * produtoDoPedido.ValorUnitario;
					}
				}
			}

			return comanda;
		}

		private IRepositorioComanda Repositorio()
		{
			return (IRepositorioComanda)_repositorio;
		}

		protected override IValidadorPadrao<Comanda> Validador()
		{
			return _validador ??= new ValidadorComanda();
		}

		protected override IConversorPadrao<Comanda, DtoComanda> Conversor()
		{
			return _conversor ??= new ConversorComanda();
		}
	}
}
