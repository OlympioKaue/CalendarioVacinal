using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IVacinasInfantis
{
    public Task AddVacinas(Vacinas vacinas);
    public Task AddCriancas(Criancas criancas);
    public Task<Criancas?> BuscarCriancaPorId(long id);
    public void AtualizarCriancas(Criancas criancas);
    public Task<List<Criancas>> BuscarCriancas();
    public Task<Profissionais?> BuscarPorId(int id);
    public void DeletarCrianca(Criancas criancas);

}
