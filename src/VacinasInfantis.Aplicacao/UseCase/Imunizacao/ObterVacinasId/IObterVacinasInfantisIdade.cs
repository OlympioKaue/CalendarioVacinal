using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasId;

public interface IObterVacinasInfantisIdade
{
    Task<RespostaCompletaDasVacinas> ObterVacinaPorID(int id);
}
