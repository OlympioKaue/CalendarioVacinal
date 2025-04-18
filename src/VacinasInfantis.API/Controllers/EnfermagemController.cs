﻿using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicadorID;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;

namespace VacinasInfantis.API.Controllers;

[Route("[controller]")]
[ApiController]
public class EnfermagemController : ControllerBase
{

    [HttpPost("RegistrarProfissionalEnfermagem")]
    [ProducesResponseType(typeof(RespostaRegistroEnfermagem), (StatusCodes.Status201Created))]
    public async Task<IActionResult> RegistrosProfissionais([FromServices] IRegistroEnfermagem useCase, [FromBody] RegistroProfissionaisSaude registro)
    {
        var result = await useCase.RegistrarProfissionaisDaEnfermagem(registro);
        return Created(string.Empty, result);
    } 

    [HttpGet("BuscarProfissionalEnfermagem")]
    [ProducesResponseType(typeof(ApenasTestelista), (StatusCodes.Status200OK))]
    public async Task<IActionResult> ObterProfissionaisDeEnfermagem([FromServices] IObterProfissionalAplicador useCase)
    {
        var result = await useCase.ObterProfissionais();
        return Ok(result);
    }

    [HttpGet("BuscarProfissionalEnfermagem,{id}")]
    [ProducesResponseType(typeof(RespostaProfissionalAplicadorDTO), (StatusCodes.Status200OK))]
    public async Task<IActionResult> ObterProfissionaisAplicador(int id, [FromServices] IObterProfissionalAplicador useCase)
    {
        var result = await useCase.ObterProfissionaisDeImunizacao(id);
        return Ok(result);
    }

}
