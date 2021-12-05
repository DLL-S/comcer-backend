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
	public class FuncionariosController : ControllerCrud<DtoFuncionario>
	{
		public FuncionariosController(IServicoDeFuncionario servico)
			: base(servico)
		{ }

		private IServicoDeFuncionario Servico()
		{
			return (IServicoDeFuncionario)_servico;
		}

		#region CONSULTAS

		[HttpGet("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public new ActionResult<DtoFuncionario> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public new ActionResult<IList<DtoFuncionario>> Listar(
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
		public new ActionResult<DtoFuncionario> Cadastrar([FromBody] DtoFuncionario obj)
		{
			return base.Cadastrar(obj);
		}

		[HttpPut()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public new ActionResult<DtoFuncionario> Atualizar([FromBody] DtoFuncionario obj)
		{
			return base.Atualizar(obj);
		}


		[HttpPatch("{codigo}/Situacao")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<EnumSituacao> AlternarSituacao(int codigo)
		{
			return Ok(Servico().AlterneSituacao(codigo));
		}
	}
}
