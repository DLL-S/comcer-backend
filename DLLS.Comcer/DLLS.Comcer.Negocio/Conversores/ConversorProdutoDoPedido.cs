using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura;
using DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorProdutoDoPedido : ConversorPadrao<ProdutoDoPedido, DtoProdutoDoPedido>, IConversorProdutoDoPedido
	{
		private RepositorioProduto repositorioProduto;
		private ConversorProduto conversorProduto;



		public override DtoProdutoDoPedido Converta(ProdutoDoPedido objeto)
		{
			DtoProdutoDoPedido dto = base.Converta(objeto);
			dto.Produto = ConversorProduto().Converta(RepositorioProduto().Consulte(objeto.IdProduto));

			return dto;
		}

		public override ProdutoDoPedido Converta(DtoProdutoDoPedido dto)
		{
			ProdutoDoPedido objeto = base.Converta(dto);
			if (dto.Produto != null)
			{
				objeto.IdProduto = dto.Produto.Id;
			}

			return objeto;
		}

		private ConversorProduto ConversorProduto()
		{
			return conversorProduto ??= new ConversorProduto();
		}
		private RepositorioProduto RepositorioProduto()
		{
			return repositorioProduto ??= new RepositorioProduto(new FabricaDeContextoDeAplicacao().CreateDbContext());
		}
	}
}
