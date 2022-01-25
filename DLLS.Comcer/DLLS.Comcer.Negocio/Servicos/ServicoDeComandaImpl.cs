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

		public DtoSaida<DtoComanda> IncluaPedido(int codgoComanda, DtoPedido pedido)
		{
			throw new System.NotImplementedException();
		}

		public override DtoSaida<DtoComanda> Cadastre(DtoComanda dto)
		{
			foreach (var pedido in dto.ListaPedidos)
			{
				pedido.Produto = _servicoDeProduto.Consulte(pedido.Produto.Id).Resultados[0];
				pedido.ValorUnitario = pedido.Produto.Preco;
				dto.Valor += pedido.Quantidade * pedido.ValorUnitario;
			}

			return base.Cadastre(dto);
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
