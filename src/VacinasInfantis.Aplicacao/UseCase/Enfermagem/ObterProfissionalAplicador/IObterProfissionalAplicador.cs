using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicador;

public interface IObterProfissionalAplicador
{
    Task<ProfissionalAplicadorDto> ObterProfissionaisAplicadores(int id);
}
