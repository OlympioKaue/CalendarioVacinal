using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasIdade;

public interface IGetVacinasInfantisIdadeUseCase
{
    Task<RespostaCompletaDasVacinas> Execute(long idade);
}
