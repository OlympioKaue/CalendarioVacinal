using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;

public class ObterCriancasUseCase : IObterCriancasUseCase
{
    private readonly IVacinasInfantis _criancas;
    private readonly IMapper _mapeamento;


    public ObterCriancasUseCase(IVacinasInfantis criancas, IMapper mapeamento)
    {
        _mapeamento = mapeamento;

        _criancas = criancas;
    }

    public async Task<RespostaDeRegistroCriancas> Execute()
    {
        // Verifica a lista de criancas, se não houver nenhuma, retorna uma mensagem de erro
        // Retorne uma lista das criancas registradas

        var result = await _criancas.BuscarCriancas();
        if (result is null)
        {
            throw new Exception("Nenhuma criança encontrada");
        }

        return new RespostaDeRegistroCriancas
        {
            Criancas = _mapeamento.Map<List<CriancasSalvas>>(result)
        };
    }
}
