using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;

public class ObterCriancasRegistradas : IObterCriancasRegistradas
{
    private readonly ICriancasRepositorio _criancas;
    private readonly IMapper _mapeamento;


    public ObterCriancasRegistradas(ICriancasRepositorio criancas, IMapper mapeamento)
    {
        _mapeamento = mapeamento;

        _criancas = criancas;
    }

    public async Task<RespostaDeRegistroCriancas> ObterCriancas()
    {
        // Verifica a lista de criancas, se não houver nenhuma, retorna uma mensagem de erro
        // Retorne uma lista das criancas registradas

        var result = await _criancas.BuscarCriancas();
        if (result is null)
        {
            throw new NaoEncontrado("Nenhuma criança encontrada");
        }

        return new RespostaDeRegistroCriancas
        {
            Criancas = _mapeamento.Map<List<CriancasSalvas>>(result)
        };
    }
}
