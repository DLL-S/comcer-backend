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
	public class FuncionariosController : ControllerCrud<DtoFuncionario>
	{
		private readonly IServicoDeUsuario _servicoDeUsuario;
		public FuncionariosController(IServicoDeFuncionario servico, IServicoDeUsuario servicoDeUsuario)
			: base(servico)
		{
			_servicoDeUsuario = servicoDeUsuario;
		}

		private IServicoDeFuncionario Servico()
		{
			return (IServicoDeFuncionario)_servico;
		}

		#region CONSULTAS

		[HttpGet("{codigo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoFuncionario> Consultar(int codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
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
		public ActionResult<DtoFuncionario> Cadastrar([FromBody] ModelCadastroDeUsuario obj)
		{
			obj.Login.Senha = ServicoAutenticador.ObtenhaCriptografado(obj.Login.Senha);
			DtoSaida<DtoFuncionario> dto = _servicoDeUsuario.CadastreUsuario(obj.Login, obj.Funcionario);

			return dto.Sucesso ? CreatedAtAction("Cadastrar", dto) : BadRequest(dto);
		}

		[HttpPut()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public new ActionResult<DtoFuncionario> Atualizar([FromBody] DtoFuncionario obj)
		{
			return base.Atualizar(obj);
		}


		[HttpPatch("{codigo}/Situacao")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[Authorize()]
		public ActionResult<EnumSituacao> AlternarSituacao(int codigo)
		{
			return Ok(Servico().AlterneSituacao(codigo));
		}
	}
}
