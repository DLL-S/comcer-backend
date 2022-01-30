using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDePedidoImpl : ServicoPadraoImpl<Pedido, DtoPedido>, IServicoDePedido
	{
		private IConversorPedido _conversor;
		private IValidadorPedido _validador;

		public ServicoDePedidoImpl(IRepositorioPedido repositorio) : base(repositorio)
		{
		}

		private IRepositorioPedido Repositorio()
		{
			return (IRepositorioPedido)_repositorio;
		}

		protected override IValidadorPadrao<Pedido> Validador()
		{
			return _validador ??= new ValidadorPedido();
		}

		protected override IConversorPadrao<Pedido, DtoPedido> Conversor()
		{
			return _conversor ??= new ConversorPedido();
		}

		public DtoSaida<DtoPedido> AtualizeStatus(int codigo, EnumStatusPedido statusPedido)
		{
			var obj = Repositorio().Consulte(codigo);

			obj.Status = statusPedido;

			var dto = Conversor().Converta(obj);

			return Atualize(dto);
		}
	}
}
