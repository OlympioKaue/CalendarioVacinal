
using AutoMapper;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.DeletarCriancas;

public class DeletarCriancas : IDeletarCriancas
{
    private readonly ICriancasRepositorio _criancas;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvar;

    public DeletarCriancas(ICriancasRepositorio criancas, IMapper mapeamento, ISalvadorDeDados salvar)
    {
        _criancas = criancas;
        _mapeamento = mapeamento;
        _salvar = salvar;
    }

    public async Task Deletar(int id)
    {
        var resultado = await _criancas.BuscarCriancaPorId(id);
        if (resultado is null)
        {
            throw new NaoEncontrado("Crianca não encontrada");
        }

        _criancas.DeletarCrianca(resultado);
        await _salvar.Commit();
    }
}
