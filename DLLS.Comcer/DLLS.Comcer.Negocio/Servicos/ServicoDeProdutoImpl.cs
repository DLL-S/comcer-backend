using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using DLLS.Comcer.Dominio.Objetos.ProdutoObj;
using DLLS.Comcer.Infraestrutura.InterfacesDeRepositorios;
using DLLS.Comcer.Interfaces.InterfacesDeConversores;
using DLLS.Comcer.Interfaces.InterfacesDeServicos;
using DLLS.Comcer.Interfaces.InterfacesDeValidacao;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Negocio.Conversores;
using DLLS.Comcer.Negocio.Validacoes;
using DLLS.Comcer.Utilitarios.Enumeradores;

namespace DLLS.Comcer.Negocio.Servicos
{
	public class ServicoDeProdutoImpl : ServicoPadraoImpl<Produto, DtoProduto>, IServicoDeProduto
	{
		private IConversorProduto _conversor;
		private IValidadorProduto _validador;

		public ServicoDeProdutoImpl(IRepositorioProduto repositorio) : base(repositorio)
		{
		}

		public override DtoSaida<DtoProduto> Liste(int pagina, int quantidade, EnumOrdem ordem, string termoDeBusca)
		{
			DtoSaida<DtoProduto> lista = base.Liste(pagina, quantidade, ordem, termoDeBusca);
			Parallel.ForEach(lista.Resultados, x => ComprimaFotoProduto(ref x));

			return lista;
		}

		private static void ComprimaFotoProduto(ref DtoProduto saidaProduto)
		{
			Image imagem;
			using (var ms = new MemoryStream(saidaProduto.Foto))
			{
				imagem = Image.FromStream(ms);
			}

			var b = new Bitmap(130, 80);

			var g = Graphics.FromImage((Image)b);
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;

			g.DrawImage(imagem, 0, 0, 130, 80);
			g.Dispose();
			imagem = (Image)b;

			using (var ms = new MemoryStream())
			{
				// Convert Image to byte[]
				imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				b.Dispose();
				byte[] imageBytes = ms.ToArray();

				saidaProduto.Foto = imageBytes;
			}
		}

		protected override IValidadorPadrao<Produto> Validador()
		{
			return _validador ??= new ValidadorProduto();
		}

		protected override IConversorPadrao<Produto, DtoProduto> Conversor()
		{
			return _conversor ??= new ConversorProduto();
		}
	}
}
