using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface ILeituraVacinasRepositorio
{
    Task<List<VacinasCriancas>> ObterVacinasCriancas();

    Task<VacinasCriancas?> ObterVacinasIdade(long idade);

    Task<List<VacinasCriancas>> ObterVacinasAtrasadas(long idade);
}
