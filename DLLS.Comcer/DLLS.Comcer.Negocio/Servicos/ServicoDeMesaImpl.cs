using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLLS.Comcer.Dominio.Objetos.MesaObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeMesaImpl : ServicoPadraoImpl<Mesa, DtoMesa>, IServicoDeMesa
	{
		private IConversorMesa _conversor;
		private IValidadorMesa _validador;
		private IServicoDeComanda _servicoDeComanda;

		public ServicoDeMesaImpl(IRepositorioMesa repositorio, IServicoDeComanda servicoDeComanda) : base(repositorio)
		{
			_servicoDeComanda = servicoDeComanda;
		}

		public DtoSaida<DtoComanda> ObtenhaComandas(int numeroMesa)
		{
			var comandas = _repositorio.Liste().Where(x => x.Numero == numeroMesa).SelectMany(x => x.Comandas);

			if (comandas != null && comandas.Any())
			{
				foreach (var comanda in comandas)
				{
					Parallel.ForEach(comanda.ListaPedidos, x =>
					{
						x.ProdutosDoPedido = null;
					});
				}
			}

			return new ConversorComanda().ConvertaParaDtoSaida(comandas.ToList());
		}

		public DtoSaida<DtoMesa> IncluaComanda(int numeroMesa, DtoComanda comanda)
		{
			var mesa = Consulte(numeroMesa).Resultados[0];

			mesa.Comandas.Add(_servicoDeComanda.TrateInclusaoDeComanda(comanda));
			mesa.Disponivel = false;
			return Atualize(mesa);
		}

		public IList<int> ObtenhaMesasAtivas()
		{
			return _repositorio.Liste().Where(x => x.Comandas.Any() && x.Disponivel == false).Select(x => x.Numero).ToList();

		}

		protected override IValidadorPadrao<Mesa> Validador()
		{
			return _validador ??= new ValidadorMesa();
		}

		protected override IConversorPadrao<Mesa, DtoMesa> Conversor()
		{
			return _conversor ??= new ConversorMesa();
		}

		private IRepositorioMesa Repositorio()
		{
			return (IRepositorioMesa)_repositorio;
		}
	}
}
