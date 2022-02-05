using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura;
using DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorProdutoDoPedido : ConversorPadrao<ProdutoDoPedido, DtoPedidoProduto>, IConversorProdutoDoPedido
	{
		RepositorioProduto repositorioProduto;
		ConversorProduto conversorProduto;



		public override DtoPedidoProduto Converta(ProdutoDoPedido objeto)
		{
			var dto = base.Converta(objeto);
			dto.Produto = ConversorProduto().Converta(RepositorioProduto().Consulte(objeto.IdProduto));

			return dto;
		}

		public override ProdutoDoPedido Converta(DtoPedidoProduto dto)
		{
			var objeto = base.Converta(dto);
			objeto.IdProduto = dto.Produto.Id;
			return objeto;
		}

		private ConversorProduto ConversorProduto()
		{
			return conversorProduto ??= new ConversorProduto();
		}
		private RepositorioProduto RepositorioProduto()
		{
			return repositorioProduto ??= new RepositorioProduto(new FabricaDeContextoDeAplicacao().CreateDbContext(null));
		}
	}
}
