using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinas;
using VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinasIdade;
using VacinasInfantis.Comunicacao.Resposta;

namespace VacinasInfantis.API.Controllers;

[Route("/[controller]")]
[ApiController]
public class VacinasInfantisController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(RespostaSimplificada), StatusCodes.Status200OK)] 
    public async Task<IActionResult> ObterVacinas([FromServices] IGetVacinasInfantisUseCase useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }

    [HttpGet]
    [Route("{idade}")]
    [ProducesResponseType(typeof(RespostaCompleta), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterIdadesVacinas([FromServices] IGetVacinasInfantisIdadeUseCase useCase, [FromRoute] long idade)
    {
        var result = await useCase.Execute(idade);
        if(result is null)
        {
            return NotFound(new {message = "Erro ao localizar"});
        }

        return Ok(result);
    }
}
