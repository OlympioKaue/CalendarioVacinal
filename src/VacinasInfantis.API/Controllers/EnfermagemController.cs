﻿using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.AtualizarProfissionais;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.DeletarProfissionais;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicadorID;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;

namespace VacinasInfantis.API.Controllers;

[ApiController]
[Route("api/v1/enfermagem")]
public class EnfermagemController : ControllerBase
{

    [HttpPost("registrar")]
    [ProducesResponseType(typeof(RespostaRegistroEnfermagem), (StatusCodes.Status201Created))]
    public async Task<IActionResult> RegistrosProfissionais([FromServices] IRegistroEnfermagem useCase, [FromBody] RegistroProfissionaisSaude registro)
    {
        var result = await useCase.RegistrarProfissionaisDaEnfermagem(registro);
        return Created(string.Empty, result);
    } 

    [HttpGet("listar")]
    [ProducesResponseType(typeof(RespostaProfissional), (StatusCodes.Status200OK))]
    public async Task<IActionResult> ObterProfissionaisDeEnfermagem([FromServices] IObterProfissionalAplicador useCase)
    {
        var result = await useCase.ObterProfissionais();
        return Ok(result);
    }

    [HttpGet("listar-profissional-aplicador/{idProfissional:int}")]
    [ProducesResponseType(typeof(RespostaProfissionalAplicadorDTO), (StatusCodes.Status200OK))]
    public async Task<IActionResult> ObterProfissionaisAplicador([FromRoute]int idProfissional, [FromServices] IObterProfissionalAplicador useCase)
    {
        var resultado = await useCase.ObterProfissionaisDeImunizacao(idProfissional);
        return Ok(resultado);
    }


    [HttpPut("atualizar/{idProfissional:int}")]
    public async Task<IActionResult> AtualizarProfissionaisDeEnfermagem([FromRoute] int idProfissional, [FromBody] RegistroProfissionaisSaude registro, 
        [FromServices] IAtualizacaoDeProfissionaisEnfermagem useCase )
    {
        await useCase.ProfissionaisDeEnfermagem(registro, idProfissional);
        return NoContent();
    }

    [HttpDelete("deletar/{idProfissional:int}")]
    public async Task<IActionResult> DeletarProfissionaisDeEnfermagem([FromRoute] int idProfissional,
      [FromServices] IDeletarProfissionaisEnfermagem useCase)
    {
        await useCase.DeletarProfissionais(idProfissional);
        return NoContent();
    }

}
