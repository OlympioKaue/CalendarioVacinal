using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Comunicacao.Resposta.Vacinas;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.Registro;

public interface IRegistroDeVacinasUseCase
{
    Task<RespostaRegistroVacinas> Executar(int criancasId, RegistroDeVacinas registroDeVacinas);
}
