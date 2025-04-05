using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasProximas;

public interface IObterVacinasUseCase
{
    Task<RespostaVacinasInfantis> Execute();
    Task<RespostaVacinasInfantis> ObterProximoMes();


}
