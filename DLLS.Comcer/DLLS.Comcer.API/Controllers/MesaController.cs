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
	public class MesaController : ControllerCrud<DtoMesa>
	{
		public MesaController(IServicoDeMesa servico)
			: base(servico)
		{ }

		private IServicoDeMesa Servico()
		{
			return (IServicoDeMesa)_servico;
		}

		#region CONSULTAS

		[HttpGet("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoMesa> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<IList<DtoMesa>> Listar(
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
		public new ActionResult<IList<DtoMesa>> ListarV2(
			[FromQuery] int pagina,
			[FromQuery] int quantidade,
			[FromQuery] EnumOrdem ordem,
			[FromQuery] string termoBuscado,
			[FromQuery] string termoDeBusca)
		{
			return base.ListarV2(pagina, quantidade, ordem, termoBuscado, termoDeBusca);
		}

		#endregion

		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoMesa> Cadastrar([FromBody] DtoMesa obj)
		{
			return base.Cadastrar(obj);
		}

		[HttpPut()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoMesa> Atualizar([FromBody] DtoMesa obj)
		{
			return base.Atualizar(obj);
		}

		[HttpPut("{codigoMesa}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public ActionResult<DtoMesa> IncluirComanda(int codigoMesa, [FromBody] DtoComanda obj)
		{
			DtoSaida<DtoMesa> dto;

			try
			{
				dto = Servico().IncluaComanda(codigoMesa, obj);

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

		[HttpPut("encerrarcomanda/{codigoComanda}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public ActionResult<DtoComanda> EncerrarComanda(int codigoComanda, [FromQuery] bool paraPagamento = false)
		{
			return Ok(Servico().EncerrarComanda(codigoComanda, paraPagamento));
		}

		[HttpGet("{codigoMesa}/Comandas")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public ActionResult<DtoSaida<DtoComanda>> ObtenhaComandas(int codigoMesa)
		{
			DtoSaida<DtoComanda> dto;

			try
			{
				dto = Servico().ObtenhaComandas(codigoMesa);

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
