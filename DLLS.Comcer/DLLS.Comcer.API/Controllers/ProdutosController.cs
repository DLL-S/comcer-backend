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
	public class ProdutosController : ControllerCrud<DtoProduto>
	{
		public ProdutosController(IServicoDeProduto servico)
			: base(servico)
		{ }

		#region CONSULTAS

		[HttpGet("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public new ActionResult<DtoProduto> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public new ActionResult<IList<DtoProduto>> Listar(
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
		public new ActionResult<IList<DtoProduto>> ListarV2(
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
		public new ActionResult<DtoProduto> Cadastrar([FromBody] DtoProduto obj)
		{
			return base.Cadastrar(obj);
		}

		[HttpPut()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoProduto> Atualizar([FromBody] DtoProduto obj)
		{
			return base.Atualizar(obj);
		}
	}
}
