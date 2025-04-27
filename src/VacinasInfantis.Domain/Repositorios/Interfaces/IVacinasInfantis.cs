using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IVacinasInfantis
{
    public Task AddVacinas(Vacinas vacinas); // ok
    Task<List<CalendarioDeVacinas>> ObterTodasVacinas(); // ok
    Task<List<Vacinas>> ObterVacinasAtual(int id); // ok
    Task<List<CalendarioDeVacinas>> ObterVacinasProximoMes(int id); // ok
    Task<Vacinas?> BuscarVacinaDaCrianca(int id, int idVacina); // ok
    Task<List<Vacinas>> ObterVacinasIdade(int id); // ok
    public void AtualizarVacinas(Vacinas vacinas); // ok
    public void DeletarVacinas(Vacinas vacinas); // ok




    public Task<Profissionais?> BuscarProfissionalDeVacinas(int id); // PRECISA SAIR DAQUI 






    //public Task AddCriancas(Criancas criancas);
    // public Task<Criancas?> BuscarCriancaPorId(long id);
    // public void AtualizarCriancas(Criancas criancas);
    // public Task<List<Criancas>> BuscarCriancas();
    //  public void DeletarCrianca(Criancas criancas);

}
