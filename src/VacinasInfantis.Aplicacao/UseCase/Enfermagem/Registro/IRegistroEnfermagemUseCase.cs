using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;

public interface IRegistroEnfermagemUseCase
{
    Task<RespostaRegistroEnfermagem> Executar(RegistroProfissionaisSaude registro);
}
