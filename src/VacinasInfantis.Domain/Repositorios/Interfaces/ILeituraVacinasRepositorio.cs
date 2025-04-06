using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface ILeituraVacinasRepositorio
{
    Task<List<Vacinas>> ObterTodasVacinas();
    Task<List<Vacinas>> ObterVacinasAtual(int id);
    Task<List<Vacinas>> ObterVacinasProximoMes(int id);
    Task<List<Vacinas>> ObterVacinasIdade(long idade);


   
}
