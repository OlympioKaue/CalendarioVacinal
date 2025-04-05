using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasProximas;

public class ObterVacinasUseCase : IObterVacinasUseCase
{
    private readonly ILeituraVacinasRepositorio _leituraVacinas;
    private readonly IMapper _mapeamento;


    public ObterVacinasUseCase(ILeituraVacinasRepositorio leituraVacinas, IMapper mapeamento)
    {
        _leituraVacinas = leituraVacinas;
        _mapeamento = mapeamento;
    }

    public async Task<RespostaVacinasInfantis> Execute()
    {
       
        var result = await _leituraVacinas.ObterVacinasAtual();


        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };


    }

    public async Task<RespostaVacinasInfantis> ObterProximoMes()
    {
        var result = await _leituraVacinas.ObterVacinasProximoMes();

        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };
    }
}
