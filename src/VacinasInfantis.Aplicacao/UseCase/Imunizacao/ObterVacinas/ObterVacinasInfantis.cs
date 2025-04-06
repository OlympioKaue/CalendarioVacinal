
using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;

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

    public async Task<RespostaVacinasInfantis> Execute()
    {
        // Obtem todas as vacinas
        // Retorne uma lista de vacinas

        var result = await _leitura.ObterTodasVacinas();

        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };
    }

}
