using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IProfissionalSaudeServico
{
    Task<List<RespostaProfissionaisEnfermagemDTO>> ObterProfissionaisAplicadores();
    Task<List<RespostaProfissional>> ObterProfissionaisDeEnfermagem();
    
}
