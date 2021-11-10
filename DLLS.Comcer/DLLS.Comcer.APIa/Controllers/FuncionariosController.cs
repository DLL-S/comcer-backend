using System.Collections.Generic;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	[Route("api/[controller]")]
	public class FuncionariosController : BaseController<DtoFuncionario>
	{
		public FuncionariosController(IServicoDeFuncionario servico)
			: base(servico)
		{

		}

		[HttpGet]
		public new ActionResult<DtoFuncionario> Consultar(long codigo)
		{
			return base.Consultar(codigo);
		}

		[HttpGet]
		public new ActionResult<IList<DtoFuncionario>> Listar()
		{
			return base.Listar();
		}

		[HttpPut]
		public new ActionResult<DtoFuncionario> Atualizar(DtoFuncionario obj)
		{
			return base.Atualizar(obj);
		}

		[HttpPost]
		public new ActionResult<DtoFuncionario> Cadastrar(DtoFuncionario obj)
		{
			return base.Cadastrar(obj);
		}

		[HttpPatch]
		public ActionResult<DtoFuncionario> AlternarAtivacao(long codigo)
		{
			return ((IServicoDeFuncionario)_Servico).AlterneAtivacao(codigo);
		}
	}
}
