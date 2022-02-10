using System;
using System.Threading.Tasks;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Globalizacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	public class AutenticacaoController : Controller
	{
		IServicoDeUsuario _servico;
		public AutenticacaoController(IServicoDeUsuario servico)
		{
			_servico = servico;
		}

		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<DtoLogin>> Authenticate([FromBody] DtoLogin model)
		{
			model.Senha = ServicoAutenticador.ObtenhaCriptografado(model.Senha);
			var usuarioDaAplicacao = _servico.ObtenhaRegistro(model.Usuario, model.Senha);
			if (usuarioDaAplicacao == null)
			{
				return NotFound(new { message = Globalizacoes.LoginInvalido });
			}

			ServicoAutenticador.ObtenhaUsuarioLogado(ref usuarioDaAplicacao);

			return usuarioDaAplicacao;
		}

		[HttpGet]
		[Route("anonymous")]
		[AllowAnonymous]
		public string Anonymous() => "Anônimo";

		[HttpGet]
		[Route("authenticated")]
		[Authorize]
		public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

		[HttpGet]
		[Route("employee")]
		[Authorize(Roles = "employee,manager")]
		public string Employee() => "Funcionário";

		[HttpGet]
		[Route("manager")]
		[Authorize(Roles = "manager")]
		public string Manager() => "Gerente";
	}
}
