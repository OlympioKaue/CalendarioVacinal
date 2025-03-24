using VacinasInfantis.Comunicacao.Resposta;

namespace VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinasIdade;

public interface IGetVacinasInfantisIdadeUseCase
{
    Task<RespostaCompleta> Execute(long idade);
}
