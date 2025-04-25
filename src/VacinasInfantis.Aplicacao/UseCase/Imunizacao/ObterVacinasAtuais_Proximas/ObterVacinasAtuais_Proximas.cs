using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasAtuais_Proximas;

public class ObterVacinasAtuais_Proximas : IObterVacinasAtuais_Proximas
{
    private readonly ILeituraVacinasRepositorio _leituraVacinas;
    private readonly IMapper _mapeamento;
    private readonly IServicoDeEmailRepositorio _email;




    public ObterVacinasAtuais_Proximas(ILeituraVacinasRepositorio leituraVacinas, IMapper mapeamento, IServicoDeEmailRepositorio email)
    {
        _leituraVacinas = leituraVacinas;
        _mapeamento = mapeamento;
        _email = email;
        

    }

    public async Task<RespostaVacinasInfantis> ObterMesAtual(int id)
    {
        // Obtem as vacinas do mês atual
        // Retorne as vacinas do mês atual


        var result = await _leituraVacinas.ObterVacinasAtual(id);
        if (result is null || result.Count == 0)
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
        if (result is null || result.Count == 0)
        {
            throw new NaoEncontrado("Nenhuma vacina encontrada para essa criança");
        }

        await _email.ExecutarNotificacao(id);

        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };
    }
}
