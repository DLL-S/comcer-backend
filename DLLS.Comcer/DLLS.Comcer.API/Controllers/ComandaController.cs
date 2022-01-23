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
		public new ActionResult<DtoComanda> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public new ActionResult<IList<DtoComanda>> Listar(
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
		public new ActionResult<DtoComanda> Cadastrar([FromBody] DtoComanda obj)
		{
			return base.Cadastrar(obj);
		}

		[HttpPut()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public new ActionResult<DtoComanda> Atualizar([FromBody] DtoComanda obj)
		{
			return base.Atualizar(obj);
		}


		[HttpPut("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<DtoComanda> IncluirPedido([FromBody] int codigo, [FromBody] DtoPedido obj)
		{
			DtoSaida<DtoComanda> dto;

			try
			{
				dto = Servico().IncluaPedido(codigo, obj);

				if (dto.Sucesso == false)
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
	}
}
