using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Interfaces.ModelosViews;
using DLLS.Comcer.Utilitarios.Enumeradores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	[ApiController]
	[Route("Api/[controller]")]
	[ApiExplorerSettings(IgnoreApi = false)]
	public class ProdutosDoPedidoController : ControllerCrud<DtoProdutoDoPedido>
	{
		public ProdutosDoPedidoController(IServicoDeProdutosDoPedido servico)
			: base(servico)
		{ }

		private IServicoDeProdutosDoPedido Servico()
		{
			return (IServicoDeProdutosDoPedido)_servico;
		}

		#region CONSULTAS

		[HttpGet("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoProdutoDoPedido> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<IList<DtoProdutoDoPedido>> Listar(
			[FromQuery] int pagina,
			[FromQuery] int quantidade,
			[FromQuery] EnumOrdem ordem,
			[FromQuery] string termoDeBusca)
		{
			return base.Listar(pagina, quantidade, ordem, termoDeBusca);
		}

		#endregion

		[HttpPut("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public ActionResult<DtoProdutoDoPedido> AtualizarStatus(int codigo, [FromQuery] EnumStatusPedido status)
		{
			DtoSaida<DtoProdutoDoPedido> dto;

			try
			{
				dto = Servico().AtualizeStatus(codigo, status);

				if (!dto.Sucesso)
				{
					return BadRequest(dto);
				}
			}
			catch
			{
				return Problem();
			}

			return Ok(dto);
		}

		[HttpGet("View/{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public ActionResult<IList<DtoPedidoProdutoView>> ListarProdutosDoPedidoView(int codigo)
		{
			IList<DtoPedidoProdutoView> saida = ((IServicoDeProdutosDoPedido)_servico).ListeItensDoPedido(codigo);
			return saida.Any() ? Ok(saida) : NoContent();
		}
	}
}
