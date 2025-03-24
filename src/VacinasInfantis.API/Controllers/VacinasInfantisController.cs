using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinas;
using VacinasInfantis.Comunicacao.Resposta;

namespace VacinasInfantis.API.Controllers;

[Route("/[controller]")]
[ApiController]
public class VacinasInfantisController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetAllVacinas), StatusCodes.Status200OK)] 
    public async Task<IActionResult> ObterVacinas([FromServices] IGetVacinasInfantisUseCase useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }
}
