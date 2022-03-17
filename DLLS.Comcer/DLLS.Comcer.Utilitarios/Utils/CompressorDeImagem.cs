using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace DLLS.Comcer.Utilitarios.Utils
{
	public static class CompressorDeImagem
	{
		public static byte[] ComprimaFotoProduto(byte[] foto)
		{
			Image imagem;
			if (foto.Length > 0)
			{
				try
				{
					using (var ms = new MemoryStream(foto))
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

						return imageBytes;
					}
				}
				catch (System.Exception)
				{
					// caso ocorra erro, retornará objeto não convertido
				}
			}

			return foto;
		}
	}
}
