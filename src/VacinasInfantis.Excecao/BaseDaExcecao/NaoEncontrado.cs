using System.Net;

namespace VacinasInfantis.Excecao.BaseDaExcecao;

public class NaoEncontrado : VacinaisInfantisExcecao
{
    // Vefica a classe VacinasInfantisExcecao possui o construtor com a base de mensagemDeErro
    public NaoEncontrado(string mensagemDeErro) : base(mensagemDeErro)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> ObterErros()
    {
        return [Message];
    }
}
