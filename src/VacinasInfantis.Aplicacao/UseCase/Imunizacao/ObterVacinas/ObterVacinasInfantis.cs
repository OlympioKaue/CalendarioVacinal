
using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinas;

public class GetVacinasInfantisUseCase : IObterVacinasInfantis
{
    private readonly ILeituraVacinasRepositorio _leitura;
    private readonly IMapper _mapeamento;

    public GetVacinasInfantisUseCase(ILeituraVacinasRepositorio leitura, IMapper mapeamento)
    {
        _leitura = leitura;
        _mapeamento = mapeamento;
    }

    public async Task<RespostaVacinasInfantis> ObterVacinas()
    {
        // Obtem todas as vacinas
        // Retorne uma lista de vacinas
        // se não houver vacinas, retorne uma exceção

        var result = await _leitura.ObterTodasVacinas();
        if(result is null)
        {
            throw new NaoEncontrado("Nenhuma vacina encontrada");
        }

        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };
    }

}
