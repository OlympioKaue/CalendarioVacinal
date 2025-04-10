using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasAtuais_Proximas;

public class ObterVacinasAtuais_Proximas : IObterVacinasAtuais_Proximas
{
    private readonly ILeituraVacinasRepositorio _leituraVacinas;
    private readonly IMapper _mapeamento;


    public ObterVacinasAtuais_Proximas(ILeituraVacinasRepositorio leituraVacinas, IMapper mapeamento)
    {
        _leituraVacinas = leituraVacinas;
        _mapeamento = mapeamento;
    }

    public async Task<RespostaVacinasInfantis> ObterMesAtual(int id)
    {
        // Obtem as vacinas do mês atual
        // Retorne as vacinas do mês atual


        var result = await _leituraVacinas.ObterVacinasAtual(id);
        if(result is null || result.Count == 0)
        {
            throw new NaoEncontrado("Nenhuma vacina encontrada para essa criança");
        }
        


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
        if(result is null || result.Count == 0)
        {
            throw new NaoEncontrado("Nenhuma vacina encontrada para essa criança");
        }

        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };
    }
}
