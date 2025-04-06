using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasProximas;

public class ObterVacinasAtuais : IObterVacinasAtuais
{
    private readonly ILeituraVacinasRepositorio _leituraVacinas;
    private readonly IMapper _mapeamento;


    public ObterVacinasAtuais(ILeituraVacinasRepositorio leituraVacinas, IMapper mapeamento)
    {
        _leituraVacinas = leituraVacinas;
        _mapeamento = mapeamento;
    }

    public async Task<RespostaVacinasInfantis> ObterMesAtual(int id)
    {
        // Obtem as vacinas do mês atual
        // Retorne as vacinas do mês atual


        var result = await _leituraVacinas.ObterVacinasAtual(id);
        


        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };


    }

    public async Task<RespostaVacinasInfantis> ObterProximoMes(int id)
    {
        // Obtem as vacinas do próximo mês
        // Retorne as vacinas do próximo mês

        var result = await _leituraVacinas.ObterVacinasProximoMes(id);

        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };
    }
}
