using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;

public interface IRegistrarCriancaUseCase
{
    Task<RespostaDeRegistroCriancas> Execute(RegistrarCriancas registrar);
}
