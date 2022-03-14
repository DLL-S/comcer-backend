using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Dominio.Views;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDePedidoImpl : ServicoPadraoImpl<Pedido, DtoPedido>, IServicoDePedido
	{
		private IConversorPedido _conversor;
		private IValidadorPedido _validador;

		public ServicoDePedidoImpl(IRepositorioPedido repositorio) : base(repositorio)
		{
		}

		public IList<DtoPedidoView> ListePedidosView()
		{
			return Conversor().Converta(((IRepositorioPedido)_repositorio).ObtenhaPedidos());
		}

		public IList<DtoPedidosComandaView> ListePedidosComandaView()
		{
			return Conversor().Converta(((IRepositorioPedido)_repositorio).ObtenhaPedidosComanda());
		}

		protected override IValidadorPadrao<Pedido> Validador()
		{
			return _validador ??= new ValidadorPedido();
		}

		protected override IConversorPedido Conversor()
		{
			return _conversor ??= new ConversorPedido();
		}
	}
}
