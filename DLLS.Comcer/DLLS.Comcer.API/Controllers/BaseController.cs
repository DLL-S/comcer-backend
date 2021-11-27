using System;
using System.Collections.Generic;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	public class BaseController<TDto> : ControllerBase where TDto : DtoBase
	{
		protected IServicoPadrao<TDto> _servico;

		protected BaseController(IServicoPadrao<TDto> servico)
		{
			_servico = servico;
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected ActionResult<TDto> Consultar(long codigo)
		{
			var obj = _servico.Consulte(codigo);

			if (obj == null)
			{
				return new NotFoundObjectResult(null);
			}

			return Ok(obj);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected ActionResult<IList<TDto>> ListarTudo()
		{
			var list = _servico.Liste();

			if (list == null || list.Count == 0)
			{
				return new NoContentResult();
			}

			return Ok(list);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected ActionResult<IList<TDto>> ListarPagina(int pagina, int quantidade, EnumOrdem ordem)
		{
			var list = _servico.Liste(pagina, quantidade, ordem);

			if (list == null || list.Count == 0)
			{
				return new NoContentResult();
			}

			return Ok(list);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected ActionResult Excluir(long codigo)
		{
			try
			{
				_servico.Exclua(codigo);
			}
			catch
			{
				return new NotFoundObjectResult(null);
			}

			return Ok();
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected ActionResult<TDto> Atualizar(TDto novoObjeto)
		{
			TDto obj;

			try
			{
				obj = _servico.Atualize(novoObjeto);

				if (obj.Sucesso == false)
				{
					return new BadRequestObjectResult(obj);
				}
			}
			catch
			{
				return new NotFoundObjectResult(null);
			}

			return Ok(obj);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected ActionResult<TDto> Cadastrar(TDto novoObjeto)
		{
			TDto obj;

			try
			{
				obj = _servico.Cadastre(novoObjeto);

				if (obj.Sucesso == false)
				{
					return new BadRequestObjectResult(obj);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return CreatedAtAction("Cadastrar", obj);
		}
	}
}