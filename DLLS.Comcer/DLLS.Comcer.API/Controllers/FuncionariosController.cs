using System.Collections.Generic;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = false)]
	public class FuncionariosController : BaseController<DtoFuncionario>
	{
		public FuncionariosController(IServicoDeFuncionario servico)
			: base(servico)
		{

		}

		private IServicoDeFuncionario Servico()
		{
			return (IServicoDeFuncionario)_servico;
		}

		[HttpGet("Consultar/{codigo}")]
		public new ActionResult<DtoFuncionario> Consultar(long codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet("Listar")]
		public ActionResult<IList<DtoFuncionario>> Listar()
		{
			return base.ListarTudo();
		}

		[HttpPut("Atualizar")]
		public new ActionResult<DtoFuncionario> Atualizar(DtoFuncionario obj)
		{
			return base.Atualizar(obj);
		}

		[HttpPost("Cadastrar")]
		public new ActionResult<DtoFuncionario> Cadastrar(DtoFuncionario obj)
		{
			return base.Cadastrar(obj);
		}

		[HttpPatch("AlternarAtivacao/{codigo}")]
		public ActionResult<DtoFuncionario> AlternarAtivacao(long codigo)
		{
			return Servico().AlterneAtivacao(codigo);
		}

		[HttpGet("Consultar")]
		public ActionResult<IList<DtoFuncionario>> Consultar(string termoDeBusca, int quantidade, EnumOrdem ordem)
		{
			var list = Servico().Consulte(termoDeBusca, quantidade, ordem);

			if (list == null || list.Count == 0)
			{
				return new NoContentResult();
			}

			return Ok(list);
		}
	}
}
