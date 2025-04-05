using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicador;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;

namespace VacinasInfantis.API.Controllers;

[Route("/[controller]")]
[ApiController]
public class EnfermagemController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(RespostaRegistroEnfermagem), (StatusCodes.Status201Created))]
    public async Task<IActionResult> RegistroProfissionais([FromServices] IRegistroEnfermagemUseCase useCase, [FromBody] RegistroProfissionaisSaude registro)
    {
        var result = await useCase.Executar(registro);
        return Created(string.Empty, result);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ProfissionalAplicadorDto), (StatusCodes.Status200OK))]
    public async Task<IActionResult> ObterProfissionaisAplicador(int id,[FromServices] IObterProfissionalAplicador useCase)
    {
        var result = await useCase.ObterProfissionaisAplicadores(id);
        return Ok(result);
    }
}
