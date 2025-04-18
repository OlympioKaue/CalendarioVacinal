using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasId;

public class ObterVacinasInfantisIdade : IObterVacinasInfantisIdade
{
    private readonly ILeituraVacinasRepositorio _leitura;
    private readonly IMapper _mapeamento;

    public ObterVacinasInfantisIdade(ILeituraVacinasRepositorio leitura, IMapper mapeamento)
    {
        _leitura = leitura;
        _mapeamento = mapeamento;
    }

    public async Task<RespostaCompletaDasVacinas> ObterVacinaPorID(int id)
    {
        // Verifica se a idade é válida
        // Idade valida de 0 a 48 meses, equivalente 0 meses a 4 anos.
        // Retorna as vacinas conforme a idade da criança.

        var result = await _leitura.ObterVacinasIdade(id);
        if(result.Count == 0)
        {
            throw new NaoEncontrado("Vacina não encontrada, digite novamente o ID da Criança");
        }

        return new RespostaCompletaDasVacinas
        {
            Vacinas = _mapeamento.Map<List<RespostaDeRegistroVacinas>>(result)
        };


    }
}
