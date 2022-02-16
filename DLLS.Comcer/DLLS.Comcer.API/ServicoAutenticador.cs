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
		private static readonly byte[] KEY = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("KEY"));
		private static readonly AesCryptoServiceProvider cryptokey = new() {
			Key = KEY.Reverse().Skip(KEY.Length - 32).ToArray(),
			IV = KEY.Skip(KEY.Length - 16).ToArray()
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
				Expires = DateTime.UtcNow.AddHours(6),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KEY), SecurityAlgorithms.HmacSha256Signature)
			};
			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			user.Senha = string.Empty;
			user.Token = tokenHandler.WriteToken(token);
		}

		public static string ObtenhaCriptografado(string texto)
		{
			var memoryStream = new MemoryStream();
			var cryptoStream = new CryptoStream(memoryStream, cryptokey.CreateEncryptor(), CryptoStreamMode.Write);
			var streamWriter = new StreamWriter(cryptoStream);
			streamWriter.WriteLine(texto);
			streamWriter.Close();
			cryptoStream.Close();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			return Convert.ToBase64String(inArray);
		}

		public static string ObtenhaDescriptografado(string texto)
		{
			var memoryStream = new MemoryStream(Convert.FromBase64String(texto));
			var cryptoStream = new CryptoStream(memoryStream, cryptokey.CreateDecryptor(), CryptoStreamMode.Read);
			var streamReader = new StreamReader(cryptoStream);
			string result = streamReader.ReadLine();
			streamReader.Close();
			cryptoStream.Close();
			memoryStream.Close();
			return result;
		}
	}
}
