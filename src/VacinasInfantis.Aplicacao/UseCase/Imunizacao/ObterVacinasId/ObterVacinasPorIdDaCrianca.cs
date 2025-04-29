using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasId;

public class ObterVacinasPorIdDaCrianca : IObterVacinasPorIdDaCrianca
{
    private readonly IVacinasInfantis _vacinas;
    private readonly IMapper _mapeamento;

    public ObterVacinasPorIdDaCrianca(IVacinasInfantis vacinas, IMapper mapeamento)
    {
        _vacinas = vacinas;
        _mapeamento = mapeamento;
    }

    public async Task<RespostaCompletaDasVacinas> ObterVacinaPorID(int id)
    {
        // Verifique o Id da Criança.
        // Retorna as vacinas conforme a idade da criança.

        var result = await _vacinas.ObterVacinasPorId(id);
        if(result.Count == 0)
        {
            throw new NaoEncontrado("Vacina não encontrada para essa criança");
        }

        return new RespostaCompletaDasVacinas
        {
            Vacinas = _mapeamento.Map<List<RespostaDeRegistroVacinas>>(result)
        };


    }
}
