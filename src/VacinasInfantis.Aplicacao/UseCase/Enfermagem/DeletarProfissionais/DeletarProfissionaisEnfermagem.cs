
using AutoMapper;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.DeletarProfissionais;

public class DeletarProfissionaisEnfermagem : IDeletarProfissionaisEnfermagem
{
    private readonly IProfissionalSaudeServico _enfermagem;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvar;


    public DeletarProfissionaisEnfermagem(IProfissionalSaudeServico enfermagem, IMapper mapeamento, ISalvadorDeDados salvar)
    {
        _enfermagem = enfermagem;
        _mapeamento = mapeamento;
        _salvar = salvar;
    }

    public async Task DeletarProfissionais(int id)
    {
        var resultado = await _enfermagem.ObterProfissionalPorId(id);
        if(resultado is null)
        {
            throw new NaoEncontrado("Profissional não encontrado");
        }

        _enfermagem.DeletarProfissionais(resultado);
        await _salvar.Commit();
    }
}
