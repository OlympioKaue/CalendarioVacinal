using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.AtualizarProfissionais;

public interface IAtualizacaoDeProfissionaisEnfermagem
{
    public Task ProfissionaisDeEnfermagem(RegistroProfissionaisSaude registro, int id);
}
