using System;
using System.Collections.Generic;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;
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

		private IServicoDePedido Servico()
		{
			return (IServicoDePedido)_servico;
		}

		#region CONSULTAS

		[HttpGet("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public new ActionResult<DtoPedido> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public new ActionResult<IList<DtoPedido>> Listar(
			[FromQuery] int pagina,
			[FromQuery] int quantidade,
			[FromQuery] EnumOrdem ordem,
			[FromQuery] string termoDeBusca)
		{
			return base.Listar(pagina, quantidade, ordem, termoDeBusca);
		}

		#endregion

		//[HttpPut("{codigo}")]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//[ProducesResponseType(StatusCodes.Status400BadRequest)]
		//public ActionResult<DtoPedido> AtualizarStatus(int codigo, [FromQuery] EnumStatusPedido status)
		//{
		//	DtoSaida<DtoPedido> dto;

		//	try
		//	{
		//		dto = Servico().AtualizeStatus(codigo, status);

		//		if (dto.Sucesso == false)
		//		{
		//			return BadRequest(dto);
		//		}
		//	}
		//	catch(Exception ex)
		//	{
		//		return Problem();
		//	}

		//	return Ok(dto);
		//}
	}
}
