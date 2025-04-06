using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.API.FiltroExcecao;

public class FiltroDeExcecao : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is VacinaisInfantisExcecao)
        {
            ExcecoesConhecidas(context);
        }
        else
        {
            ExcecoesDesconhecidas(context);
        }
    }


    private void ExcecoesConhecidas(ExceptionContext context)
    {
    }

    private void ExcecoesDesconhecidas(ExceptionContext context)
    {
        var resultado = new RespostaDeErro("Erro Descconheccido - 500");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(resultado);
        // ObjectResult pega o resultado e devolve a reposta em HTTP para o usuario.
    }



}
