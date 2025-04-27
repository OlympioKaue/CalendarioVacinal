using AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.Validacoes;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.AtualizarCriancas;

public class AtualizacaoDeCriancas : IAtualizacaoDeCriancas
{
    private readonly ICriancasRepositorio _criancas;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvar;

    public AtualizacaoDeCriancas(ICriancasRepositorio criancas, IMapper mapeamento, ISalvadorDeDados salvar)
    {
        _criancas = criancas;
        _mapeamento = mapeamento;
        _salvar = salvar;
    }

    public async Task Atualizar(InfantilCriancas registrar, int id)
    {
        Validate(registrar);

        var resultado = await _criancas.BuscarCriancaPorId(id);
        if(resultado is null)
        {
            throw new Excecoes("Crianca não encontrada");
        }

       _mapeamento.Map(registrar, resultado);
       _criancas.AtualizarCriancas(resultado);
        await _salvar.Commit();


    }

    private void Validate(InfantilCriancas registrar)
    {
        var validacao = new ValidarRegistrosDeCriancas();
        var resultado = validacao.Validate(registrar);

        if(resultado.IsValid is false)
        {
            var erros = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            throw new Excecoes(erros);
        }
    }
}
