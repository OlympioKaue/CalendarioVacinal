using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinas;

public interface IObterVacinasInfantis
{
    Task<RespostaVacinasInfantis> Execute();
}
