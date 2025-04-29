using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface ICriancasRepositorio
{
    public Task AddCriancas(Criancas criancas); // ok
    public Task<Criancas?> BuscarCriancaPorId(long id); //ok
    public void AtualizarCriancas(Criancas criancas); // ok
    public Task<List<Criancas>> BuscarCriancas(); //ok
    public void DeletarCrianca(Criancas criancas); //ok

}

