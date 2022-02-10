using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DLLS.Comcer.Interfaces.Modelos;
using Microsoft.IdentityModel.Tokens;

namespace DLLS.Comcer.API
{
	public static class ServicoAutenticador
	{
		static readonly byte[] KEY = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b92fedaf7d8863b48e197b9287d492b708e87d49fedaf7d886fedaf7d8863b48e197b9287d492b708e3b48e197b9287fedaf7d8863b48e197b9287d492b708ed492b708e2b708e");
		static RC2CryptoServiceProvider cryptokey = new RC2CryptoServiceProvider {
			Key = KEY.Reverse().Skip(KEY.Length - 16).ToArray(),
			IV = KEY.Skip(KEY.Length - 8).ToArray()
		};

		public static byte[] ObtenhaByteKey()
		{
			return KEY;
		}

		public static void ObtenhaUsuarioLogado(ref DtoLogin user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor {
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Usuario.ToString()),
					new Claim(ClaimTypes.Role, user.Role.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KEY), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			user.Senha = string.Empty;
			user.Token = token.ToString();
		}

		public static string ObtenhaCriptografado(string texto)
		{
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptokey.CreateEncryptor(), CryptoStreamMode.Write);
			StreamWriter streamWriter = new StreamWriter(cryptoStream);
			streamWriter.WriteLine(texto);
			streamWriter.Close();
			cryptoStream.Close();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			return Convert.ToBase64String(inArray);
		}

		public static string ObtenhaDescriptografado(string texto)
		{
			MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(texto));
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptokey.CreateDecryptor(), CryptoStreamMode.Read);
			StreamReader streamReader = new StreamReader(cryptoStream);
			string result = streamReader.ReadLine();
			streamReader.Close();
			cryptoStream.Close();
			memoryStream.Close();
			return result;
		}
	}
}
