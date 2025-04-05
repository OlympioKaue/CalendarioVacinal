using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;

public interface IObterCriancasUseCase
{
    Task<RespostaDeRegistro> Execute();
}
