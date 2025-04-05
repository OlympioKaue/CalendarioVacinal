using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinas;

public interface IGetVacinasInfantisUseCase
{
    Task<RespostaVacinasInfantis> Execute();
}
