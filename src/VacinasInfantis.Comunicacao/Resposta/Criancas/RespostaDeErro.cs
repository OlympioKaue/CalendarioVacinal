namespace VacinasInfantis.Comunicacao.Resposta.Criancas;

public class RespostaDeErro
{
    public List<string> RespostaErros { get; set; } = [];

    public RespostaDeErro(string erro)
    {
        RespostaErros = [erro];
    }

    public RespostaDeErro(List<string> erro)
    {
        RespostaErros = erro;
    }


}
