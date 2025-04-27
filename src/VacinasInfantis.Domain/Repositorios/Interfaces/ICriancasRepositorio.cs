using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface ICriancasRepositorio
{
    // interface responsável por adicionar, atualizar, deletar e buscar as crianças
    public Task AddCriancas(Criancas criancas); // ok
    public Task<Criancas?> BuscarCriancaPorId(long id); //ok
    public void AtualizarCriancas(Criancas criancas); // ok
    public Task<List<Criancas>> BuscarCriancas(); //ok
    public void DeletarCrianca(Criancas criancas); //ok



    /*
    Task<List<CalendarioDeVacinas>> ObterTodasVacinas();
    Task<List<Vacinas>> ObterVacinasAtual(int id);
    Task<List<CalendarioDeVacinas>> ObterVacinasProximoMes(int id);
    Task<List<Vacinas>> ObterVacinasIdade(int id);                        // DANDO CERTO AQUI, VAMOS APAGAR OQUE ESTA EM BAIXO
    Task<Vacinas> BuscarVacinasDaCrianca(int idVacina, int idCrianca);
    public void DeletarVacinas(Vacinas vacinas);
    public void AtualizarVacinas(Vacinas vacinas);
    */
}

