using DLLS.Comcer.Dominio.Objetos.Funcionario;
using DLLS.Comcer.Interfaces.InterfacesDeRepositorios;

namespace DLLS.Comcer.Infraestrutura.Mapeadores.Repositorios
{
    public class RepositorioFuncionario : RepositorioObjetoComIdNumerico<Funcionario>, IRepositorioFuncionario
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
        public RepositorioFuncionario(ContextoPadrao contexto)
            : base(contexto) { }
    }
}
