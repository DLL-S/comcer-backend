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
		public new ActionResult<DtoMesa> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public new ActionResult<IList<DtoMesa>> Listar(
			[FromQuery] int pagina,
			[FromQuery] int quantidade,
			[FromQuery] EnumOrdem ordem,
			[FromQuery] string termoDeBusca)
		{
			return base.Listar(pagina, quantidade, ordem, termoDeBusca);
		}

		#endregion

		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public new ActionResult<DtoMesa> Cadastrar([FromBody] DtoMesa obj)
		{
			return base.Cadastrar(obj);
		}

		[HttpPut()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public new ActionResult<DtoMesa> Atualizar([FromBody] DtoMesa obj)
		{
			return base.Atualizar(obj);
		}

		[HttpPut("{codigoMesa}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<DtoMesa> IncluirComanda(int codigoMesa, [FromBody] DtoComanda obj)
		{
			DtoSaida<DtoMesa> dto;

			try
			{
				dto = Servico().IncluaComanda(codigoMesa, obj);

				if (dto.Sucesso == false)
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

		[HttpGet("{codigoMesa}/Comandas")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<DtoSaida<DtoComanda>> ObtenhaComandas(int codigoMesa)
		{
			DtoSaida<DtoComanda> dto;

			try
			{
				dto = Servico().ObtenhaComandas(codigoMesa);

				if (dto.Sucesso == false)
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