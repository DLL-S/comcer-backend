using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Objetos.ComandaObj;
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
		private readonly IServicoDeComanda _servicoDeComanda;

		public ServicoDeMesaImpl(IRepositorioMesa repositorio, IServicoDeComanda servicoDeComanda) : base(repositorio)
		{
			_servicoDeComanda = servicoDeComanda;
		}

		public DtoSaida<DtoComanda> ObtenhaComandas(int numeroMesa)
		{
			IEnumerable<Comanda> comandas = Repositorio().Liste().Where(x => x.Numero == numeroMesa).SelectMany(x => x.Comandas);

			return new ConversorComanda().ConvertaParaDtoSaida(comandas.ToList());
		}

		public DtoSaida<DtoMesa> IncluaComanda(int numeroMesa, DtoComanda comanda)
		{
			DtoMesa mesa = Consulte(numeroMesa).Resultados[0];

			mesa.Comandas.Add(_servicoDeComanda.TrateInclusaoDeComanda(comanda));
			mesa.Disponivel = false;
			return Atualize(mesa);
		}

		public IList<int> ObtenhaMesasAtivas()
		{
			return Repositorio().Liste().Where(x => x.Comandas.Any() && !x.Disponivel).Select(x => x.Numero).ToList();

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
