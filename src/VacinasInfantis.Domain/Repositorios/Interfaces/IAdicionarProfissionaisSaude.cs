using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IAdicionarProfissionaisSaude
{
    Task AddEnfermagem(Profissionais profissionais); // ok
}
