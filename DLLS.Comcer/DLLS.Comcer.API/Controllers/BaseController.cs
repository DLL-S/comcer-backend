using System.Collections.Generic;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	public class BaseController<TDto> : ControllerBase where TDto : DtoBase
	{
		protected IServicoPadrao<TDto> _Servico;

		protected BaseController(IServicoPadrao<TDto> servico)
		{
			_Servico = servico;
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected ActionResult<TDto> Consultar(long codigo)
		{
			var obj = _Servico.Consulte(codigo);

			if (obj.Sucesso == false)
			{
				return new NotFoundObjectResult(null);
			}

			return Ok(obj);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		protected ActionResult<IList<TDto>> Listar()
		{
			var list = _Servico.Liste();

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
				_Servico.Exclua(codigo);
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
				obj = _Servico.Atualize(novoObjeto);

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
				obj = _Servico.Cadastre(novoObjeto);

				if (obj.Sucesso == false)
				{
					return new BadRequestObjectResult(obj);
				}
			}
			catch
			{
				return new NotFoundObjectResult(null);
			}

			return CreatedAtAction("Cadastrar", obj);
		}
	}
}
