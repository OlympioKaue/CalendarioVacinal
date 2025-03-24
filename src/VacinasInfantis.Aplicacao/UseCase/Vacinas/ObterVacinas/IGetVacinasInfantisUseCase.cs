using VacinasInfantis.Comunicacao.Resposta;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinas;

public interface IGetVacinasInfantisUseCase
{
    Task<RespostaVacinasInfantis> Execute();
}
