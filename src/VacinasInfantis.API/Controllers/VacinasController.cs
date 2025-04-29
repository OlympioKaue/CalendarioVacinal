using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.AtualizarVacinas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.DeletarVacinas;
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
    [Route("registrar/{idCrianca:int}")]
    [ProducesResponseType(typeof(RespostaRegistroVacinas), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarVacina([FromServices] IRegistroDeImunizantes useCase, [FromBody] RegistroDeVacinas registrar,
        [FromRoute] int idCrianca)
    {

        var result = await useCase.Executar(idCrianca, registrar);
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
    [Route("listar/{idCrianca:int}")]
    [ProducesResponseType(typeof(RespostaCompletaDasVacinas), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterIdadesVacinas([FromServices] IObterVacinasPorIdDaCrianca useCase, [FromRoute] int idCrianca)
    {
        var result = await useCase.ObterVacinaPorID(idCrianca);

        return Ok(result);
    }


    [HttpGet]
    [Route("listar-vacinasAtuais/{idCrianca:int}")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> VacinasaAtuais([FromRoute] int idCrianca, [FromServices] IObterVacinasAtuais_Proximas useCase)
    {
        var result = await useCase.ObterMesAtual(idCrianca);
        return Ok(result);
    }

    [HttpGet]
    [Route("listar-vacinasMesSeguinte/enviarNotificacao/{idCrianca:int}")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> VacinasProximoMes([FromRoute] int idCrianca, [FromServices] IObterVacinasAtuais_Proximas useCase)
    {
      
        var result = await useCase.ObterProximoMes(idCrianca);

        return Ok(result);
    }

    [HttpPut]
    [Route("atualizar-vacinas/{idCrianca:int}/{idVacina:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AtualizarVacinas([FromRoute] int idCrianca, [FromRoute] int idVacina, [FromBody] RegistroDeVacinas registrar, [FromServices] IAtualizarImunizantes useCase)
    {

        await useCase.AtualizarVacinas(idCrianca, idVacina, registrar);
        return NoContent();
    }

    [HttpDelete]
    [Route("deletar-vacinas/{idCrianca:int}/{idVacina:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AtualizarVacinas([FromRoute] int idCrianca, [FromRoute] int idVacina, [FromServices] IDeletarImunizantes useCase)
    {

        await useCase.DeletarVacinas(idCrianca, idVacina);
        return NoContent();
    }

}
