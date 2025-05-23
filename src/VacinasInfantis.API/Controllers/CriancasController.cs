﻿using Microsoft.AspNetCore.Mvc;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.AtualizarCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.DeletarCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.API.Controllers;

[ApiController]
[Route("api/v1/criancas")]
public class CriancasController : ControllerBase
{
    [HttpPost("registrar")]
    [ProducesResponseType(typeof(CriancasSalvas), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarCrianca([FromServices] IRegistrosDeCriancas useCase, [FromBody] InfantilCriancas registrar)
    {
        var result = await useCase.Execute(registrar);
        return Created(string.Empty, result);
    }


    [HttpGet("listar")]
    public async Task<IActionResult> ObterCriancas([FromServices] IObterCriancasRegistradas useCase)
    {
        var result = await useCase.ObterCriancas();
        return Ok(result);
    }

    [HttpPut("atualizar/{idCrianca:int}")]
    public async Task<IActionResult> AtualizarCrianca([FromRoute] int idCrianca, [FromServices] IAtualizacaoDeCriancas useCase, [FromBody] InfantilCriancas registrar)
    {
        await useCase.Atualizar(registrar, idCrianca);
        return NoContent();
    }


    [HttpDelete("deletar/{idCrianca:int}")]
    public async Task<IActionResult> DeletarCrianca([FromRoute] int idCrianca, [FromServices] IDeletarCriancas useCase)
    {
        await useCase.Deletar(idCrianca);
        return NoContent();
    }

}
