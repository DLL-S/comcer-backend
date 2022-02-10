using System;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Globalizacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DLLS.Comcer.API.Controllers
{
	public class AutenticacaoController : Controller
	{
		readonly IServicoDeUsuario _servico;
		public AutenticacaoController(IServicoDeUsuario servico)
		{
			_servico = servico;
		}

		[HttpPost]
		[Route("login")]
		public ActionResult<DtoLogin> Authenticate([FromBody] DtoLogin model)
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
	}
}
