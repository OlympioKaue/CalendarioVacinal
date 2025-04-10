using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;

public interface IObterCriancasRegistradas
{
    Task<RespostaDeRegistroCriancas> ObterCriancas();
}
