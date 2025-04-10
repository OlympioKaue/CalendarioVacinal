using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasAtuais_Proximas;

public interface IObterVacinasAtuais_Proximas
{
    Task<RespostaVacinasInfantis> ObterMesAtual(int id);
    Task<RespostaVacinasInfantis> ObterProximoMes(int id);


}
