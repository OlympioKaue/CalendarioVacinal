using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface ILeituraVacinasRepositorio
{
    Task<List<Vacinas>> ObterVacinasCriancas();
    Task<List<Vacinas>> ObterVacinasAtual();
    Task<List<Vacinas>> ObterVacinasProximoMes();

    Task<Vacinas?> ObterVacinasIdade(long idade);

    Task<List<Vacinas>> ObterVacinasAtrasadas(long idade);


   
}
