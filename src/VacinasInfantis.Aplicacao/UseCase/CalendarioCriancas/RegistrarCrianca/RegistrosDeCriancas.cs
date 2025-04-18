using AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.Validacoes;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;

public class RegistrosDeCriancas : IRegistrosDeCriancas
{
    private readonly IVacinasInfantis _adicionar;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvadorDeDados;
    public RegistrosDeCriancas(IVacinasInfantis adicionar, ISalvadorDeDados salvadorDeDados, IMapper mapeamento)
    {
        _adicionar = adicionar;
        _mapeamento = mapeamento;
        _salvadorDeDados = salvadorDeDados;
    }

    public async Task<CriancasSalvas> Execute(RegistrarCriancas registrar)
    {
        // Primeiro valide os objetos de entrada

        // mapear o objeto de entrada para a entidade
        // adicione criancas ao banco de dados
        // e salve as alterações
        // retorne o objeto mapeado de resposta

        ValidarCrianca(registrar);

        var entity = _mapeamento.Map<Criancas>(registrar);

        await _adicionar.AddCriancas(entity);

        await _salvadorDeDados.Commit();

        return _mapeamento.Map<CriancasSalvas>(entity);
    }

    private void ValidarCrianca(RegistrarCriancas registrar)
    {
        var validacao = new ValidarRegistrosDeCriancas();
        var resultado = validacao.Validate(registrar);

        if(resultado.IsValid is false)
        {
            var listaDeErros = resultado.Errors.Select(v => v.ErrorMessage).ToList();
            throw new Excecoes(listaDeErros);
        }
    }

    
}
