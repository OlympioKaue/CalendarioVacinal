using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasIdade;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasProximas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.Registro;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Vacinas;

namespace VacinasInfantis.API.Controllers;

[Route("[controller]")]
[ApiController]
public class VacinasController : ControllerBase
{
    [HttpPost]
    [Route("RegistrarVacina,{id}")]
    [ProducesResponseType(typeof(RespostaRegistroVacinas), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarVacina([FromServices] IRegistroDeImunizantes useCase, [FromBody] RegistroDeVacinas registrar, 
        [FromRoute] int id)
    {
      
        var result = await useCase.Executar(id, registrar);
        return Created(" ", result);
    }


    [HttpGet("ObterTodasVacinas")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterVacinas([FromServices] IObterVacinasInfantis useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }



    [HttpGet]
    [Route("VacinasPor{idade}")]
    [ProducesResponseType(typeof(RespostaCompletaDasVacinas), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterIdadesVacinas([FromServices] IGetVacinasInfantisIdadeUseCase useCase, [FromRoute] long idade)
    {
        var result = await useCase.Execute(idade);
        if (result is null)
        {
            return NotFound(new { message = "Erro ao localizar" });
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("VacinasAtuais/VacinasTomadas,{id}")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> VacinasaAtuais(int id, [FromServices] IObterVacinasAtuais useCase)
    {
        var result = await useCase.ObterMesAtual(id);
        return Ok(result);
    }

    [HttpGet]
    [Route("VacinaProximoMes,{id}")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> VacinasProximoMes(int id, [FromServices] IObterVacinasAtuais useCase)
    {
        var result = await useCase.ObterProximoMes(id);
        if(result is null || result.Vacinas.Count is 0)
        {
            return NotFound("Nenhuma vacina encontrada");
        }

        return Ok(result);
    }
}
