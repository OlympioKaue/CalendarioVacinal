
using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinas;

public class GetVacinasInfantisUseCase : IGetVacinasInfantisUseCase
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
        var result = await _leitura.ObterVacinasCriancas();

        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };
    }
}
