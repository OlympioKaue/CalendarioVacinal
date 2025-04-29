using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IProfissionalSaudeServico
{
    Task<List<RespostaProfissionaisEnfermagemDTO>> ObterProfissionaisAplicadores(); // ok
    Task<List<RespostaProfissional>> ObterProfissionaisDeEnfermagem(); // ok
    Task<Profissionais?> ObterProfissionalPorId(int id); // ok
    public void AtualizarProfissionais(Profissionais profissionais); // ok
    public void DeletarProfissionais(Profissionais profissionais); // ok

}
