using System;
using System.Collections.Generic;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	[ApiController]
	[Route("Api/[controller]")]
	[ApiExplorerSettings(IgnoreApi = false)]
	public class ComandaController : ControllerCrud<DtoComanda>
	{
		public ComandaController(IServicoDeComanda servico)
			: base(servico)
		{ }

		private IServicoDeComanda Servico()
		{
			return (IServicoDeComanda)_servico;
		}

		#region CONSULTAS

		[HttpGet("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoComanda> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<IList<DtoComanda>> Listar(
			[FromQuery] int pagina,
			[FromQuery] int quantidade,
			[FromQuery] EnumOrdem ordem,
			[FromQuery] string termoDeBusca)
		{
			return base.Listar(pagina, quantidade, ordem, termoDeBusca);
		}

		[HttpGet("v2")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<IList<DtoComanda>> ListarV2(
			[FromQuery] int pagina,
			[FromQuery] int quantidade,
			[FromQuery] EnumOrdem ordem,
			[FromQuery] string termoBuscado,
			[FromQuery] string termoDeBusca)
		{
			return base.ListarV2(pagina, quantidade, ordem, termoBuscado, termoDeBusca);
		}

		#endregion

		[HttpPut()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoComanda> Atualizar([FromBody] DtoComanda obj)
		{
			return base.Atualizar(obj);
		}

		[HttpPut("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public ActionResult<DtoComanda> IncluirPedido(int codigo, [FromBody] DtoPedido obj)
		{
			DtoSaida<DtoComanda> dto;

			try
			{
				dto = Servico().IncluaPedido(codigo, obj);

				if (!dto.Sucesso)
				{
					return BadRequest(dto);
				}
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}

			return Ok(dto);
		}
	}
}
