
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.DeletarVacinas;

public class DeletarImunizantes : IDeletarImunizantes
{
    private readonly IVacinasInfantis _vacinas;
    private readonly ISalvadorDeDados _salvar;

    public DeletarImunizantes(IVacinasInfantis vacinas, ISalvadorDeDados salvar)
    {
        _vacinas = vacinas;
        _salvar = salvar;
    }

    public async Task DeletarVacinas(int idVacina, int idCrianca)
    {
        var resultado = await _vacinas.BuscarVacinaDaCrianca(idVacina, idCrianca);
        if(resultado == null)
        {
            throw new NaoEncontrado("A vacina não encontrada");
        }

        _vacinas.DeletarVacinas(resultado);
        await _salvar.Commit();
        
    }
}
