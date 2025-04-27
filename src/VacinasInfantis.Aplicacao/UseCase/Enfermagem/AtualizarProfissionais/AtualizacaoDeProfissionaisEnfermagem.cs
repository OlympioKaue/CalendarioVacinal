using AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Validacoes;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.AtualizarProfissionais;

public class AtualizacaoDeProfissionaisEnfermagem : IAtualizacaoDeProfissionaisEnfermagem
{
    private readonly IProfissionalSaudeServico _enfermagem;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvar;

    public AtualizacaoDeProfissionaisEnfermagem(IProfissionalSaudeServico enfermagem, IMapper mapeamento, ISalvadorDeDados salvar)
    {
        _enfermagem = enfermagem;
        _mapeamento = mapeamento;
        _salvar = salvar;
    }

    public async Task ProfissionaisDeEnfermagem(RegistroProfissionaisSaude registro, int id)
    {
        Validate(registro);

        var resultado = await _enfermagem.ObterProfissionalPorId(id);
        if (resultado is null)
        {
            throw new NaoEncontrado("Profissional não encontrado");
        }

        _mapeamento.Map(registro, resultado);
        _enfermagem.AtualizarProfissionais(resultado);
        await _salvar.Commit();


    }

    private void Validate(RegistroProfissionaisSaude registro)
    {
        var validacoes = new ValidarRegistrosDeEnfermagem();
        var resultado = validacoes.Validate(registro);

        if (resultado.IsValid is false)
        {
            var erros = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            throw new Excecoes(erros);
        }
    }
}
