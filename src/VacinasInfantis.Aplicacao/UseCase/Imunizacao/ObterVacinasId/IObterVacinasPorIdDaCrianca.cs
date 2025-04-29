using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasId;

public interface IObterVacinasPorIdDaCrianca
{
    Task<RespostaCompletaDasVacinas> ObterVacinaPorID(int id);
}
