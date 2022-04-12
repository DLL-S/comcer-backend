using System.Collections.Generic;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Infraestrutura;
using DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;

namespace DLLS.Comcer.Negocio.Conversores
{
	public class ConversorProdutoDoPedido : ConversorPadrao<ProdutoDoPedido, DtoProdutoDoPedido>, IConversorProdutoDoPedido
	{
		private RepositorioProduto repositorioProduto;
		private ConversorProduto conversorProduto;

		public IList<DtoPedidoProdutoView> Converta(IList<PedidoProdutoView> obj)
		{
			var lista = new List<DtoPedidoProdutoView>();
			foreach (PedidoProdutoView item in obj)
			{
				lista.Add(Converta(item));
			}

			return lista;
		}

		public DtoPedidoProdutoView Converta(PedidoProdutoView obj)
		{
			return Copie<DtoPedidoProdutoView, PedidoProdutoView>(obj);
		}

		public override DtoProdutoDoPedido Converta(ProdutoDoPedido objeto)
		{
			DtoProdutoDoPedido dto = base.Converta(objeto);
			dto.Produto = ConversorProduto().Converta(RepositorioProduto().Consulte(objeto.IdProduto));
			if (dto.Status == Utilitarios.Enumeradores.EnumStatusPedido.CANCELADO)
			{
				dto.ValorUnitario = 0;
			}

			return dto;
		}

		public override ProdutoDoPedido Converta(DtoProdutoDoPedido dto)
		{
			ProdutoDoPedido objeto = base.Converta(dto);
			if (dto.Produto != null)
			{
				objeto.IdProduto = dto.Produto.Id;
			}

			if (objeto.Status == Utilitarios.Enumeradores.EnumStatusPedido.CANCELADO)
			{
				dto.ValorUnitario = 0;
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
