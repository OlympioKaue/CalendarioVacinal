using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasProximas;

public interface IObterVacinasAtuais
{
    Task<RespostaVacinasInfantis> ObterMesAtual(int id);
    Task<RespostaVacinasInfantis> ObterProximoMes(int id);


}
