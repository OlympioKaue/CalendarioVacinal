using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.AtualizarCriancas;

public interface IAtualizacaoDeCriancas
{
    public Task Atualizar (InfantilCriancas registrar, int id);
}
