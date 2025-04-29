using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IVacinasInfantis
{
    public Task AddVacinas(Vacinas vacinas); // ok
    Task<List<CalendarioDeVacinas>> ObterTodasVacinas(); // ok
    Task<List<Vacinas>> ObterVacinasAtual(int id); // ok
    Task<List<CalendarioDeVacinas>> ObterVacinasProximoMes(int id); // ok
    Task<Vacinas?> BuscarVacinaDaCrianca(int id, int idVacina); // ok
    Task<List<Vacinas>> ObterVacinasPorId(int id); // ok
    public void AtualizarVacinas(Vacinas vacinas); // ok
    public void DeletarVacinas(Vacinas vacinas); // ok
    public Task<Profissionais?> BuscarProfissionalDeVacinas(int id); //ok



}
