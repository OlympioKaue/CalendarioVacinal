using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinasIdade;

public class GetVacinasInfantisIdadeUseCase : IGetVacinasInfantisIdadeUseCase
{
    private readonly ILeituraVacinasRepositorio _leitura;
    private readonly IMapper _mapeamento;

    public GetVacinasInfantisIdadeUseCase(ILeituraVacinasRepositorio leitura, IMapper mapeamento)
    {
        _leitura = leitura;
        _mapeamento = mapeamento;
    }

    public async Task<RespostaCompleta> Execute(long idade)
    {
        var result = await _leitura.ObterVacinasAtrasadas(idade);

        return new RespostaCompleta
        {
            Vacinas = _mapeamento.Map<List<RespostaVacinas>>(result)
        };


    }
}
