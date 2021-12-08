using System.Collections.Generic;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Enumeradores;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	public abstract class ControllerCrud<TDto> : ControllerBase where TDto : DtoBase
	{
		protected IServicoPadrao<TDto> _servico;

		protected ControllerCrud(IServicoPadrao<TDto> servico)
		{
			_servico = servico;
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected virtual ActionResult<TDto> Consultar(int codigo)
		{
			var dto = _servico.Consulte(codigo);
			return dto == null ? NotFound() : Ok(dto);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected virtual ActionResult<IList<TDto>> Listar(
			[FromQuery] int pagina,
			[FromQuery] int quantidade,
			[FromQuery] EnumOrdem ordem,
			[FromQuery] string termoDeBusca)
		{
			var saida = _servico.Liste(pagina, quantidade, ordem, termoDeBusca);
			return saida == null || saida.Resultados.Count == 0 ? NoContent() : Ok(saida);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected virtual ActionResult<TDto> Cadastrar([FromBody] TDto novoObjeto)
		{
			var dto = _servico.Cadastre(novoObjeto);
			return dto.Sucesso ? CreatedAtAction("Consultar", dto) : BadRequest(dto);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected virtual ActionResult<TDto> Atualizar([FromBody] TDto novoObjeto)
		{
			DtoSaida<TDto> dto;

			try
			{
				dto = _servico.Atualize(novoObjeto);

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

		[ApiExplorerSettings(IgnoreApi = true)]
		protected virtual ActionResult Excluir(int codigo)
		{
			try
			{
				_servico.Exclua(codigo);
			}
			catch
			{
				return NotFound(codigo);
			}

			return Ok();
		}
	}
}
