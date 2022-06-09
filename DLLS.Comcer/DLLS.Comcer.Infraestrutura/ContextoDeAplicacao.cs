using DLLS.Comcer.Dominio.Objetos.ComandaObj;
using DLLS.Comcer.Dominio.Objetos.Compartilhados;
using DLLS.Comcer.Dominio.Objetos.FuncionarioObj;
using DLLS.Comcer.Dominio.Objetos.IdentityObj;
using DLLS.Comcer.Dominio.Objetos.MesaObj;
using DLLS.Comcer.Dominio.Objetos.PedidoObj;
using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Dominio.Views;
using DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos;
using DLLS.Comcer.Infraestrutura.Mapeadores.Mapeamentos.Identidade;
using DLLS.Comcer.Interfaces.ModelosViews;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLLS.Comcer.Infraestrutura
{
	/// <summary>
	/// Contexto padrão da aplicação.
	/// </summary>
	public class ContextoDeAplicacao : IdentityDbContext<Usuario, Role, int>
	{
		/// <summary>
		/// Inicia uma nova instância do contexto.
		/// </summary>
		/// <param name="opcoes"></param>
		public ContextoDeAplicacao(DbContextOptions<ContextoDeAplicacao> opcoes) : base(opcoes)
		{
		}

		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<ProdutoDoPedido> ProdutosDosPedidos { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<Comanda> Comandas { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }
		public DbSet<Mesa> Mesas { get; set; }
		public DbSet<PedidoView> PedidosView { get; set; }
		public DbSet<PedidoProdutoView> PedidosDoProdutoView { get; set; }
		public DbSet<PedidosComandaView> PedidosComandaView { get; set; }

		/// <summary>
		/// Define os mapeamentos a serem aplicados durante a criação do modelo para o contexto.
		/// </summary>
		/// <param name="builder"></param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			AddConfiguracoesDoIdentity(builder);
			AddConfiguracoesDoDominio(builder);

			builder.Entity<PedidoView>(x =>
			{
				x.HasNoKey();
				x.ToSqlQuery(
					  "select " +
								"p.\"ID\" as NumeroPedido, " +
								"m.\"NUMERO\" as NumeroMesa, " +
								"case " +
									"when(select count(*) from (select count(*) as contEntregue, (select count(*) from (select \"STATUS\" from \"PEDIDOSDOPRODUTO\" pp where \"PEDIDO\" = p.\"ID\" AND \"STATUS\" <> 'CANCELADO' group by \"STATUS\") listaTotal) as contTotal from (select \"STATUS\" from \"PEDIDOSDOPRODUTO\" pp where \"PEDIDO\" = p.\"ID\" AND \"STATUS\" <> 'CANCELADO' group by \"STATUS\") listaStatus where \"STATUS\" = 'ENTREGUE') Contaentregue where Contaentregue.contEntregue = Contaentregue.contTotal) = 1 then 'ENTREGUE' " +
									"when(select count(*) from(select \"STATUS\" from \"PEDIDOSDOPRODUTO\" pp where \"PEDIDO\" = p.\"ID\" AND \"STATUS\" <> 'CANCELADO' group by \"STATUS\") listaStatus where \"STATUS\" <> 'ENTREGUE' and \"STATUS\" <> 'PRONTO') = 0 then 'PRONTO' " +
									"else 'PENDENTE' " +
								"end as StatusPedido " +
							"from \"PEDIDOS\" p " +
								"inner join \"COMANDAS\" c " +
									"on p.\"COMANDA\" = c.\"ID\" " +
								"inner join \"MESAS\" m  " +
									"on m.\"ID\" = c.\"MESA\""
				);

				x.Property(y => y.StatusPedido).HasConversion<string>();
			});

			builder.Entity<PedidoProdutoView>(x =>
			{
				x.HasNoKey();
				x.ToSqlQuery(
					  "select " +
							"p.\"ID\" as NumeroPedido, " +
							"coalesce(m.\"NUMERO\", 0) as NumeroMesa, " +
							"pp.\"ID\" as IdProdutoPedido, " +
							"prod.\"NOME\" as ProdutoPedido, " +
							"pp.\"DATAHORAPEDIDO\" as DataHoraPedido, " +
							"pp.\"STATUS\" as StatusPedido " +
						"from \"PEDIDOS\" p " +
							"inner join \"COMANDAS\" c  " +
								"on p.\"COMANDA\" = c.\"ID\" " +
							"left join \"MESAS\" m  " +
								"on m.\"ID\" = c.\"MESA\" " +
							"inner join \"PEDIDOSDOPRODUTO\" pp " +
								"on pp.\"PEDIDO\" = p.\"ID\"  " +
							"inner join \"PRODUTOS\" prod " +
								"on prod.\"ID\" = pp.\"IDPRODUTO\" "
				);

				x.Property(y => y.StatusPedido).HasConversion<string>();
				x.Property(y => y.DataHoraPedido);
			});

			builder.Entity<PedidosComandaView>(x =>
			{
				x.HasNoKey();
				x.ToSqlQuery(
					  "select  " +
							"c.\"ID\" as idComanda, " +
							"m.\"NUMERO\" as numeroMesa, " +
							"c.\"NOME\" as nomeComanda, " +
							"c.\"VALOR\" as valorTotalComanda, " +
							"c.\"STATUS\" statusComanda, " +
							"pp.\"ID\" idDoProdutoDoPedido, " +
							"prod.\"NOME\" as nomeProdutoDoPedido, " +
							"prod.\"DESCRICAO\" as descricaoProdutoDoPedido, " +
							"prod.\"PRECO\" precoProdutoDoPedido, " +
							"prod.\"FOTO\" as fotoProdutoDoPedido, " +
							"pp.\"QUANTIDADE\" as quantidadeProdutoDoPedido, " +
							"pp.\"STATUS\" as statusProdutoDoPedido, " +
							"pp.\"DATAHORAPEDIDO\" as dataHoraPedido " +
						"from \"PEDIDOSDOPRODUTO\" pp " +
						"inner join \"PEDIDOS\" p " +
							"on p.\"ID\" = pp.\"PEDIDO\" " +
						"inner join \"COMANDAS\" c " +
							"on p.\"COMANDA\" = c.\"ID\" " +
						"inner join \"MESAS\" m " +
							"on c.\"MESA\" = m.\"ID\" " +
						"left join \"PRODUTOS\" prod  " +
							"on prod.\"ID\" = pp.\"IDPRODUTO\" "
				);

				x.Property(y => y.StatusProdutoDoPedido).HasConversion<string>();
				x.Property(y => y.StatusComanda).HasConversion<string>();
				x.Property(y => y.FotoProdutoDoPedido).HasConversion<string>();
			});
		}

		private static void AddConfiguracoesDoDominio(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new EnderecoMap());
			builder.ApplyConfiguration(new FuncionarioMap());
			builder.ApplyConfiguration(new ProdutoMap());
			builder.ApplyConfiguration(new EnderecoMap());
			builder.ApplyConfiguration(new PedidoMap());
			builder.ApplyConfiguration(new PedidoProdutoMap());
			builder.ApplyConfiguration(new ComandaMap());
			builder.ApplyConfiguration(new MesaMap());
		}

		private static void AddConfiguracoesDoIdentity(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new UsuarioMap());
			builder.ApplyConfiguration(new RolesMap());
			builder.ApplyConfiguration(new ClaimsMap());
			builder.ApplyConfiguration(new TokenMap());
			builder.ApplyConfiguration(new UsuarioLoginMap());
			builder.ApplyConfiguration(new RoleClaimMap());
			builder.ApplyConfiguration(new UsuarioRoleMap());
		}
	}
}
