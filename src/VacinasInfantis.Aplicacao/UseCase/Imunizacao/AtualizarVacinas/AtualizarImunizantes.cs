using AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.Validacoes;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.AtualizarVacinas;

public class AtualizarImunizantes : IAtualizarImunizantes
{
    private readonly IVacinasInfantis _vacinas;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvar;

    public AtualizarImunizantes(IVacinasInfantis vacinas, IMapper mapeamento, ISalvadorDeDados salvar)
    {
        _vacinas = vacinas;
        _mapeamento = mapeamento;
        _salvar = salvar;
    }

    public async Task AtualizarVacinas(int id, int idVacina, RegistroDeVacinas registro)
    {
        Validate(registro);

       var resultado = await _vacinas.BuscarVacinaDaCrianca(id, idVacina);
        if (resultado == null)
        {
            throw new NaoEncontrado("A vacina não existe");
        }


        _mapeamento.Map(registro, resultado);
        _vacinas.AtualizarVacinas(resultado);
        await _salvar.Commit();


    }

    private void Validate(RegistroDeVacinas registro)
    {
        var validacao = new ValidarVacinasRegistradas();
        var resultado = validacao.Validate(registro);

        if(resultado.IsValid is false)
        {
            var erro = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            throw new Excecoes(erro);
        }


    }
}
