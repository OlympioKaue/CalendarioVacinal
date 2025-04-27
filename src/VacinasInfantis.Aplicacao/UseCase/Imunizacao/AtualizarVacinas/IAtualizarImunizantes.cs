using VacinasInfantis.Comunicacao.Requisicao.Vacinas;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.AtualizarVacinas;

public interface IAtualizarImunizantes
{
    public Task AtualizarVacinas(int id, int idVacina, RegistroDeVacinas registro);
}
