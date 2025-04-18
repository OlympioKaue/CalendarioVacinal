using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface ILeituraVacinasRepositorio
{
    Task<List<CalendarioDeVacinas>> ObterTodasVacinas();
    Task<List<Vacinas>> ObterVacinasAtual(int id);
    Task<List<CalendarioDeVacinas>> ObterVacinasProximoMes(int id);
    Task<List<Vacinas>> ObterVacinasIdade(int id);
  



}
