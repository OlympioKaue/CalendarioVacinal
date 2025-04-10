namespace VacinasInfantis.Excecao.BaseDaExcecao;

public abstract class VacinaisInfantisExcecao : SystemException
{
    // Passe a base (mensagemDeErro) para SystemException
    protected VacinaisInfantisExcecao(string MensagemDeErro) : base(MensagemDeErro)
    {

    }

    public abstract int StatusCode { get; }
    public abstract List<string> ObterErros();


}
