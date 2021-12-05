using System;
using System.Collections.Generic;
using System.Linq;
using DLLS.Comcer.Dominio.Modelos;
using DLLS.Comcer.Interfaces.Modelos;
using DLLS.Comcer.Utilitarios.Utils;

namespace DLLS.Comcer.Negocio
{
	public static class CentralDeValidacoes
	{
		public static void InserirRetornoValidacao<TDto, TObjeto>(
			ref TDto dto,
			TObjeto objetoAValidar,
			Func<TObjeto, IList<InconsistenciaDeValidacao>> metodoDeValidacao) where TDto : DtoBase
		{
			var retornoValidacao = metodoDeValidacao.Invoke(objetoAValidar);

			if (retornoValidacao.Any(x => x.Impeditivo == true))
			{
				dto.Sucesso = false;
			}

			foreach (var item in retornoValidacao)
			{
				dto.Validacoes ??= new List<MensagemDeValidacao>();
				dto.Validacoes.Add(new MensagemDeValidacao(item.Propriedade, item.Mensagem, item.Impeditivo));
			}
		}
	}
}
