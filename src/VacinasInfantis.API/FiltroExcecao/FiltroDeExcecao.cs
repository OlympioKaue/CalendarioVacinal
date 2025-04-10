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
        var vacinasExcecao =(VacinaisInfantisExcecao)context.Exception;
        var RespostaDeErro = new RespostaDeErro(vacinasExcecao.ObterErros());

        context.HttpContext.Response.StatusCode = vacinasExcecao.StatusCode;
        context.Result = new ObjectResult(RespostaDeErro);

        
    }
    

    private void ExcecoesDesconhecidas(ExceptionContext context)
    {
        var RespostaDeErro = new RespostaDeErro("Erro Descconheccido - 500");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(RespostaDeErro);
        // ObjectResult pega o resultado e devolve a reposta em HTTP para o usuario.
    }



}
