using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CriancasController : ControllerBase
{
    [HttpPost("RegistrarCriancas")]
    [ProducesResponseType(typeof(CriancasSalvas), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarCrianca([FromServices] IRegistrosDeCriancas useCase, [FromBody] RegistrarCriancas registrar)
    {
        var result = await useCase.Execute(registrar);
        return Created(string.Empty, result);
    }


    [HttpGet("BuscarCriancasRegistradas")]
    public async Task<IActionResult> ObterCriancas([FromServices] IObterCriancasRegistradas useCase)
    {
        var result = await useCase.ObterCriancas();
        return Ok(result);
    }


}
