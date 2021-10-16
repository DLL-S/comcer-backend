using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLLS.Comcer.Interfaces.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DLLS.Comcer.APIa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionariosController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<DtoFuncionario> Listar()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new DtoFuncionario
				{
            })
            .ToArray();
        }
    }
}
