using AutoMapper;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;

public class RegistrarCriancaUseCase : IRegistrarCriancaUseCase
{
    private readonly IVacinasInfantis _adicionar;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvadorDeDados;
    public RegistrarCriancaUseCase(IVacinasInfantis adicionar, ISalvadorDeDados salvadorDeDados, IMapper mapeamento)
    {
        _adicionar = adicionar;
        _mapeamento = mapeamento;
        _salvadorDeDados = salvadorDeDados;
    }

    public async Task<RespostaDeRegistroCriancas> Execute(RegistrarCriancas registrar)
    {
        // mapear o objeto de entrada para a entidade
        // adicione criancas ao banco de dados
        // e salve as alterações
        // retorne o objeto mapeado de resposta

        var entity = _mapeamento.Map<Criancas>(registrar);

        await _adicionar.AddCriancas(entity);

        await _salvadorDeDados.Commit();

        return _mapeamento.Map<RespostaDeRegistroCriancas>(entity);
    }
}
