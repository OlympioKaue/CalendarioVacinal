namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.DeletarVacinas;

public interface IDeletarImunizantes
{
    Task DeletarVacinas(int idVacina, int idCrianca);
}
