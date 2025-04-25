using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasAtuais_Proximas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasId;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.Registro;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Vacinas;

namespace VacinasInfantis.API.Controllers;

[ApiController]
[Route("api/v1/vacinas")]
public class VacinasController : ControllerBase
{

    [HttpPost]
    [Route("registrar/{id:int}")]
    [ProducesResponseType(typeof(RespostaRegistroVacinas), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarVacina([FromServices] IRegistroDeImunizantes useCase, [FromBody] RegistroDeVacinas registrar,
        [FromRoute] int id)
    {

        var result = await useCase.Executar(id, registrar);
        return Created(string.Empty, result);
    }


    [HttpGet("listar")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterVacinas([FromServices] IObterVacinasInfantis useCase)
    {
        var result = await useCase.ObterVacinas();
        return Ok(result);
    }



    [HttpGet]
    [Route("listar/{id:int}")]
    [ProducesResponseType(typeof(RespostaCompletaDasVacinas), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterIdadesVacinas([FromServices] IObterVacinasInfantisIdade useCase, [FromRoute] int id)
    {
        var result = await useCase.ObterVacinaPorID(id);

        return Ok(result);
    }


    [HttpGet]
    [Route("listar-vacinasAtuais/{id:int}")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> VacinasaAtuais([FromRoute] int id, [FromServices] IObterVacinasAtuais_Proximas useCase)
    {
        var result = await useCase.ObterMesAtual(id);
        return Ok(result);
    }

    [HttpGet]
    [Route("listar-vacinasMesSeguinte/enviarNotificacao/{id:int}")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> VacinasProximoMes([FromRoute] int id, [FromServices] IObterVacinasAtuais_Proximas useCase)
    {
      
        var result = await useCase.ObterProximoMes(id);

        return Ok(result);
    }


}
