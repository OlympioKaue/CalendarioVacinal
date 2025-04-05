using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasIdade;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasProximas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.Registro;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Vacinas;

namespace VacinasInfantis.API.Controllers;

[Route("Registro/[controller]")]
[ApiController]
public class VacinasController : ControllerBase
{
    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(RespostaRegistroVacinas), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarVacina([FromServices] IRegistroDeVacinasUseCase useCase, [FromBody] RegistroDeVacinas registrar, 
        [FromRoute] int id)
    {
      
        var result = await useCase.Executar(id, registrar);
        return Created(" ", result);
    }


    [HttpGet("ObterTodasVacinas")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterVacinas([FromServices] IGetVacinasInfantisUseCase useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }



    [HttpGet]
    [Route("VacinasPor{idade}")]
    [ProducesResponseType(typeof(RespostaCompleta), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterIdadesVacinas([FromServices] IGetVacinasInfantisIdadeUseCase useCase, [FromRoute] long idade)
    {
        var result = await useCase.Execute(idade);
        if (result is null)
        {
            return NotFound(new { message = "Erro ao localizar" });
        }

        return Ok(result);
    }


    [HttpGet("VacinasAtuais/VacinasTomadas")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> VacinasaAtuais([FromServices] IObterVacinasUseCase useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }

    [HttpGet("VacinasProximoMês")]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)]
    public async Task<IActionResult> VacinasProximoMes([FromServices] IObterVacinasUseCase useCase)
    {
        var result = await useCase.ObterProximoMes();
        if(result is null || result.Vacinas.Count is 0)
        {
            return NotFound("Nenhuma vacina encontrada");
        }

        return Ok(result);
    }
}
