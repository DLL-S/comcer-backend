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
	public class PedidosController : ControllerCrud<DtoPedido>
	{
		public PedidosController(IServicoDePedido servico)
			: base(servico)
		{ }

		#region CONSULTAS

		[HttpGet("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoPedido> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<IList<DtoPedido>> Listar(
			[FromQuery] int pagina,
			[FromQuery] int quantidade,
			[FromQuery] EnumOrdem ordem,
			[FromQuery] string termoDeBusca)
		{
			return base.Listar(pagina, quantidade, ordem, termoDeBusca);
		}

		[HttpGet("View")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public ActionResult<IList<DtoPedidoView>> ListarPedidosView()
		{
			IList<DtoPedidoView> saida = ((IServicoDePedido)_servico).ListePedidosView();
			return saida.Any() ? Ok(saida) : NoContent();
		}
		#endregion
	}
}
