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

		[HttpGet("Consultar/{codigo}")]
		public new ActionResult<DtoFuncionario> Consultar(long codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet("Listar")]
		public new ActionResult<IList<DtoFuncionario>> Listar()
		{
			return base.Listar();
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
			return ((IServicoDeFuncionario)_Servico).AlterneAtivacao(codigo);
		}
	}
}
