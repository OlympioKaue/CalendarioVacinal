using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.API.Controllers;

[Route("Registros/Criancas[controller]")]
[ApiController]
public class CriancasController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CriancasSalvas), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarCrianca([FromServices] IRegistrarCriancaUseCase useCase, [FromBody] RegistroVacinal register)
    {
        var result = await useCase.Execute(register);
        return Created(string.Empty, result);
    }


    [HttpGet]
    public async Task<IActionResult> ObterCriancas([FromServices] IObterCriancasUseCase useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }


}
