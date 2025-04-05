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

    public async Task<RespostaDeRegistro> Execute(RegistroVacinal request)
    {
        var entity = _mapeamento.Map<Criancas>(request);

        await _adicionar.AddCriancas(entity);

        await _salvadorDeDados.Commit();

        return _mapeamento.Map<RespostaDeRegistro>(entity);
    }
}
